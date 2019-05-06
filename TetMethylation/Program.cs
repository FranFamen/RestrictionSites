using System;
using System.Linq;
using System.Collections.Generic;


namespace TetMethylation
{
    class Program
    {
        private static List<int> sixCount;
        private static int j = 0;
        static List<string> sixCharacterWithComplementary, copySixCharacterWithComplementary;

        private static string NitrogenousBase { get; set; }

        private Program()
        {
            NitrogenousBase = string.Empty;
            sixCharacterWithComplementary = new List<string>();
            copySixCharacterWithComplementary = new List<string>();
            sixCount = new List<int>();
        }

        static void Main(string[] args)
        {
            var nitrobase = new Program();
            NitrogenousBase = "ATATATATATTATATATACCGATCATGCATGGCATACCGTATA";
            Program.GetSixesWithComplementary(NitrogenousBase);
            Program.CompareSixes(sixCharacterWithComplementary);
        }

        private static void GetSixesWithComplementary(string DNAString)
        {
            //var nitrogenousBase = "CCGATCATGCATGGCATACCGTATA";
            var nitrogenousBaseTable = new List<char>();
            var sixCharacters = new List<string>();
            //var nitrobase = new Program();
            var complementaryPairs = new Dictionary<char, char>
            {
                {'A', 'T'},
                {'T', 'A'},
                {'G', 'C'},
                {'C', 'G'}
            };

            foreach (var x in NitrogenousBase)
            {
                nitrogenousBaseTable.Add(x);
            }
            for (var i = 0; i + 5 < nitrogenousBaseTable.Count(); i++)
            {
                sixCharacters.Add(NitrogenousBase.Substring(i, 6));
            }
            foreach (var six in sixCharacters)
            {
                var pair = new Dictionary<char, char>();
                var charactersInSix = six.ToCharArray();
                if (complementaryPairs.ContainsKey(charactersInSix[0]) && complementaryPairs[charactersInSix[0]].Equals(charactersInSix[5]) &&
                    complementaryPairs.ContainsKey(charactersInSix[1]) && complementaryPairs[charactersInSix[1]].Equals(charactersInSix[4]) &&
                    complementaryPairs.ContainsKey(charactersInSix[2]) && complementaryPairs[charactersInSix[2]].Equals(charactersInSix[3]))
                {
                    sixCharacterWithComplementary.Add(six);
                }
            }
        }
    
        private static void CompareSixes (List <string> Sixer)
        {
            var complementaryArray = new string[sixCharacterWithComplementary.Count];
            sixCharacterWithComplementary.CopyTo(complementaryArray);
            var length = complementaryArray.Length;
            var j = 0;
            while (j < sixCharacterWithComplementary.Count)
            {
                string actual = Sixer[j];
                sixCount.Add(Sixer.FindAll(six => six.Equals(actual)).Count);
                var count = 0;

                for (int i = 0; i < length-count; i ++)
                {
                    string temp = sixCharacterWithComplementary[i];
                    if (temp == actual)
                    {
                        sixCharacterWithComplementary.Remove(actual);
                        i--;
                        count++;
                    }
                }
                length -= count;
                Console.WriteLine(actual + " " + count);
            }
            /*int i = 0;
            while (i <= sixCount.Capacity)
            {
                Console.WriteLine(sixCount[i]);
                int toSkip = sixCount[i];
                i += toSkip;
            }
            foreach (var six in sixCount)
            {
                Console.WriteLine(six);
            }*/
        }
    }
}
