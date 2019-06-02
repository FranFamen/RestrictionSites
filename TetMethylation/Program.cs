using System;
using System.Linq;
using System.Collections.Generic;


namespace TetMethylation
{
    class Program
    {
        private List<string> firstDNAStrandSixesList = new List<string>();
        private List<string> secondDNAStrandSixesList = new List<string>();
        private Dictionary<string, Tuple<int,int>> sixesWithOccurance = new Dictionary<string, Tuple<int, int>>();
        private List<string> listOfOutput = new List<string>();
        private Program()
        {
            for (var i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    firstDNAStrandSixesList = ComplementarySixes.GetSixesWithComplementary(i);
                }

                if (i == 1)
                {
                    secondDNAStrandSixesList = ComplementarySixes.GetSixesWithComplementary(i);
                }
            }

            sixesWithOccurance = TwoDNAStrands.CompareSixes(firstDNAStrandSixesList, secondDNAStrandSixesList);
            listOfOutput = DataOutput.CreateTableOfData(sixesWithOccurance);
            foreach (var oneLineOutput in listOfOutput )
            {
               // Console.WriteLine(oneLineOutput);

                //System.IO.File.WriteAllLines("C:\\Users\\Franciszek\\source\\repos\\TetMethylation2\\OUTPUT.txt", oneLineOutput);
            }
            System.IO.File.WriteAllLines("C:\\Users\\Franciszek\\source\\repos\\TetMethylation2\\OUTPUT.txt", listOfOutput.ToArray());


        }

        static void Main(string[] args)
        {
            var nitrobase = new Program();
            
        }

        
    

    }
}
