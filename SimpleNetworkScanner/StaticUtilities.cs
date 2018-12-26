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
            while (reader.Peek() == ' ') reader.Read();
            while (reader.Peek() != ' ') s += reader.Read();
            s.Replace("\n", "");
            return s;
        }

    }
}
