using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TetMethylation
{
    public class DNAStrand
    {
        private static string strand { get; set; }
        public static string ReadDNAStrand(int numberOfStrand)
        {
            string fileText = File.ReadAllText("C:\\Users\\Franciszek\\source\\repos\\TetMethylation2\\DNAStrand" + (numberOfStrand + 1).ToString() + ".txt");
            return fileText.ToUpper();
            
        }
        

    }
}
