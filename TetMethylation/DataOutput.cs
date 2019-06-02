using System;
using System.Collections.Generic;
using System.Text;

namespace TetMethylation
{
    class DataOutput
    {
        public static List<string> CreateTableOfData(Dictionary<string, Tuple<int, int>> sixesWithOccurance)
        {
            var sixesWithOccurancesString = new List<string>();
            sixesWithOccurancesString.Add("Complementary pair:       Occurance in first strand:         Occurance in second strand:");
            foreach (var sixWithOccurence in sixesWithOccurance)
            {
                var sixWithOccuranceInString = sixWithOccurence.Key + "                |                  " + sixWithOccurence.Value.Item1.ToString() +
                                               "              |                  " + sixWithOccurence.Value.Item2.ToString();
                sixesWithOccurancesString.Add(sixWithOccuranceInString);
            }
            return sixesWithOccurancesString;
        }
    }
}
