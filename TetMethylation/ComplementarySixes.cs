﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace TetMethylation
{
    class ComplementarySixes
    {
        public static List<string> GetSixesWithComplementary(int numberOfStrand)
        {
            //input ze ścieżką do pliku
            var nitrogenousBase = DNAStrand.ReadDNAStrand(numberOfStrand);
            List<string> sixCharacterWithComplementary, sixCharacterWithComplementaryWithRepeated;
            sixCharacterWithComplementary = new List<string>();
            sixCharacterWithComplementaryWithRepeated = new List<string>();
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
                    sixCharacterWithComplementaryWithRepeated.Add(six);
                }

            }

            foreach (var six in sixCharacterWithComplementaryWithRepeated)
            {
                if (!sixCharacterWithComplementary.Contains(six))
                {
                    sixCharacterWithComplementary.Add(six);
                }
            }



            //foreach (var six in sixCharacterWithComplementaryWithNumber)
            //{
            //    Console.WriteLine(six);
            //}
            return sixCharacterWithComplementaryWithRepeated;
        }
    }
}
