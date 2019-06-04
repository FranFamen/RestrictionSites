using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace TetMethylation
{
    public class DNAStrand
    {
        private static string strand { get; set; }
        public static string ReadDNAStrand(int numberOfStrand)
        {
            string fileText = File.ReadAllText("C:\\Users\\Franciszek\\source\\repos\\TetMethylation2\\DNAStrand" + (numberOfStrand + 1).ToString() + ".txt");
            fileText = Regex.Escape(fileText).Replace("\\", "").Replace("r", "").Replace("n", "");
            return fileText.ToUpper().Trim();

        }
        

    }
}
