using System;
using System.Collections.Generic;
using System.Text;

namespace TetMethylation
{
    class TwoDNAStrands
    {
        public static Dictionary<string, Tuple<int,int>> CompareSixes(List<string> firstDNAStrandSixesWithRepetition, List<string> secondDNAStrandSixesWithRepetition)
        {
            var firstDNAStrandSixes = new List<string>();
            var secondDNAStrandSixes = new List<string>();
            var firstDNAStrandSixesWithNumber = new Dictionary<string, int>();
            var secondDNAStrandSixesWithNumber = new Dictionary<string, int>();
            var sixesWithNumbersFromBothStrands = new Dictionary<string, Tuple<int, int>>();
            //Wyciągam słownik z szóstką i jej ilością wystąpień w nici dla nici pierwszej
            foreach (var six in firstDNAStrandSixesWithRepetition)
            {
                if (!firstDNAStrandSixes.Contains(six))
                {
                    firstDNAStrandSixes.Add(six);
                }
            }
            foreach (var six in firstDNAStrandSixes)
            {
                var repetition = 0;
                foreach (var repeatedSix in firstDNAStrandSixesWithRepetition)
                {
                    if (repeatedSix == six)
                    {
                        repetition++;
                    }
                }
                firstDNAStrandSixesWithNumber.Add(six, repetition);
            }
            //Wyciągam słownik z szóstką i jej ilością wystąpień w nici dla nici drugiej
            foreach (var six in secondDNAStrandSixesWithRepetition)
            {
                if (!secondDNAStrandSixes.Contains(six))
                {
                    secondDNAStrandSixes.Add(six);
                }
            }
            foreach (var six in secondDNAStrandSixes)
            {
                var repetition = 0;
                foreach (var repeatedSix in secondDNAStrandSixesWithRepetition)
                {
                    if (repeatedSix == six)
                    {
                        repetition++;
                    }
                }
                secondDNAStrandSixesWithNumber.Add(six, repetition);
            }

            foreach (var sixWithNumberFirst in firstDNAStrandSixesWithNumber)
            {
                var isInOtherStrand = false;
                var occurenceFromSecondStrand = 0;
                foreach (var sixWithNumberSecond in secondDNAStrandSixesWithNumber)
                {
                    if (sixWithNumberFirst.Key == sixWithNumberSecond.Key)
                    {
                        occurenceFromSecondStrand = sixWithNumberSecond.Value;
                        isInOtherStrand = true;
                    }
                }
                if (isInOtherStrand)
                {
                    secondDNAStrandSixesWithNumber.Remove(sixWithNumberFirst.Key);
                }

                sixesWithNumbersFromBothStrands.Add(sixWithNumberFirst.Key, new Tuple<int, int>(sixWithNumberFirst.Value, occurenceFromSecondStrand));
            }
            foreach (var sixWithNumberSecond in secondDNAStrandSixesWithNumber)
            {
                sixesWithNumbersFromBothStrands.Add(sixWithNumberSecond.Key, new Tuple<int, int>(0, sixWithNumberSecond.Value));
            }

            return sixesWithNumbersFromBothStrands;
        }
    }
}
