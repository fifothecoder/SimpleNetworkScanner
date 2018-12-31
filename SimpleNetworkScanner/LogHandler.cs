using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetworkScanner
{
    public static class LogHandler
    {
        public static List<string> LOG_CACHE { get; private set; }

        public static void AddLog(string message)
        {
            if (LOG_CACHE == null) LOG_CACHE = new List<string>();
            LOG_CACHE.Add(message);
        }
    }
}
