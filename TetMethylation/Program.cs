using System;
using System.Linq;
using System.Collections.Generic;


namespace TetMethylation
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        private static void GetSixesWithComplementary(string DNAString)
        {
            var nitrogenousBase = "CCGATCATGCATGGCATACCGTATA";
            var nitrogenousBaseTable = new List<char>();
            var sixCharacters = new List<string>();
            var complementaryPairs = new Dictionary<char, char>
            {
                {'A', 'T'},
                {'T', 'A'},
                {'G', 'C'},
                {'C', 'G'}
            };
            var sixCharacterWithComplementary = new List<string>();
            foreach (var x in nitrogenousBase)
            {
                nitrogenousBaseTable.Add(x);
            }
            for (var i = 0; i + 5 < nitrogenousBaseTable.Count(); i++)
            {
                sixCharacters.Add(nitrogenousBase.Substring(i, 6));
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
    }
}
