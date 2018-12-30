using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

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

        
        public static bool TryParseIPv4(this string value, out IPAddress output)
        {

            string[] arrOctets = value.Split('.');
            if (arrOctets.Length != 4)
            {
                output = null;
                return false;
            }
            
            foreach (string strOctet in arrOctets)
            {
                if (strOctet.Length > 3)
                {
                    output = null;
                    return false;
                }

                if (!byte.TryParse(strOctet, out var num))
                {
                    output = null;
                    return false;
                }
            }
            output = IPAddress.Parse(value);
            return true;


        } 

    }
}
