using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace SimpleNetworkScanner
{
    public static class Settings
    {
        public const string SETTINGS_PATH = "settings.sns";
        public static Dictionary<string, string> SETTINGS_LIST;

        public static void InitSettings()
        {
            SETTINGS_LIST = new Dictionary<string, string>();
            using (StreamReader reader = new StreamReader(SETTINGS_PATH))
            {
            }
        }

        public static bool IsValidSetting(string s)
        {
            return new string[] { "WIN_WIDTH", "WIN_HEIGHT", "LAST_SESSION"}.Contains(s.ToUpper());
        }
    }
}
