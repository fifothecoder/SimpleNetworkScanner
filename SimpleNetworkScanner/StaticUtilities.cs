using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetworkScanner
{
    public static class StaticUtilities
    {
        
        public static string ReadWord(this StreamReader reader)
        {
            string s = string.Empty;
            while ((reader.Peek() == ' ' || reader.Peek() == '\n') && !reader.EndOfStream)
               reader.Read();
            while (reader.Peek() != ' ' && reader.Peek() != '\n' && !reader.EndOfStream)
                s += (char)reader.Read();
            s = s.Replace('\n', '*');
            s = s.Replace('\r', '*');
            s = s.Replace("*", "");             //'*' is not allowed char in naming files, thus can't be in the name
            return s;
        }

    }
}
