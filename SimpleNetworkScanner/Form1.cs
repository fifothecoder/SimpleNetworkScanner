using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleNetworkScanner
{
    public partial class FormMain : Form
    {
        


        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                CheckLastSaveExist();
                Settings.InitSettings();
            } catch (Exception ex)
            {
                MessageBox.Show("Error while working with the settings file occured!");
                MessageBox.Show($"Exception data : {ex.ToString()}");
            }
        }

        private void CheckLastSaveExist()
        {
            if (File.Exists(Settings.SETTINGS_PATH) && !CheckSettingsCorrupted()) return;
                
            btnLast.Enabled = false;
            if (File.Exists(Settings.SETTINGS_PATH)) File.Delete(Settings.SETTINGS_PATH);
            File.Create(Settings.SETTINGS_PATH);

            try
            {
                using (StreamWriter writer = new StreamWriter(Settings.SETTINGS_PATH))
                {
                    writer.WriteLine("WIN_WIDTH 640");
                    writer.WriteLine("WIN_HEIGHT 400");
                }
            }
            catch (IOException) { throw new Exception("Error occured while creating the settings file!"); }
            catch (Exception) { throw; }
        }

        private bool CheckSettingsCorrupted()
        {
            int wordCount = 0;
            using (StreamReader reader = new StreamReader(Settings.SETTINGS_PATH))
            {
                if (reader.EndOfStream) return false;       //Check if settings aren't empty

                bool isValue = false;
                
                while(reader.EndOfStream)                   //Check for every tuple
                {
                    string cache = reader.ReadWord();
                    if(isValue)
                    {
                        wordCount++;
                        isValue = false;
                    } else
                    {
                        if (!Settings.IsValidSetting(cache)) return false;
                        wordCount++;
                        isValue = true;
                    }
                }
            }
            return wordCount % 2 == 1;
        }

    }
}
