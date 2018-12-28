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
        public const uint SETTINGS_COUNT = 4;
        private static Dictionary<string, string> SETTINGS_LIST;

        public static void InitSettings()
        {
            SETTINGS_LIST = new Dictionary<string, string>();
            using (StreamReader reader = new StreamReader(SETTINGS_PATH))
            {
                while (!reader.EndOfStream)
                {
                    string key = reader.ReadWord();
                    if (key == string.Empty) break;
                    else SETTINGS_LIST.Add(key, reader.ReadLine().Trim());
                }
            }

            if (SETTINGS_LIST.ContainsKey("LAST_SAVE") && !File.Exists(SETTINGS_LIST["LAST_SAVE"])) SETTINGS_LIST.Remove("LAST_SAVE");
        }
        public static bool IsValidSetting(string s)
        {
            bool b = new string[] { "WIN_SIZE", "LAST_SAVE"}.Contains(s.ToUpper());
            return b;
        }

        public static bool HasKey(string s) { return SETTINGS_LIST.ContainsKey(s); }

        public static string GetSetting(string key) { return SETTINGS_LIST[key]; ;  }

        public static void SetSetting(string key, string value) {
            if (SETTINGS_LIST.ContainsKey(key)) SETTINGS_LIST[key] = value;
            else SETTINGS_LIST.Add(key, value);
        }

        public static void SaveSettings()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(SETTINGS_PATH))
                {
                    foreach (var item in SETTINGS_LIST) writer.WriteLine($"{item.Key} {item.Value}");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Unable to save settings file!");
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
    }
}
