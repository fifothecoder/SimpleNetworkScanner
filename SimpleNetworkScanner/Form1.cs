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
                btnLast.Enabled = Settings.HasKey("LAST_SAVE");
                FormClosing += (x, y) => { Settings.SaveSettings(); };
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

            try
            {
                using (StreamWriter writer = new StreamWriter(Settings.SETTINGS_PATH))
                {
                    writer.WriteLine("WIN_SIZE 600x400");
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
                bool isValue = false;
                
                while(!reader.EndOfStream)                   //Check for every tuple
                {
                    string cache = reader.ReadWord();
                    if(cache == string.Empty) return wordCount != Settings.SETTINGS_COUNT;
                    if (isValue)
                    {
                        wordCount++;
                        isValue = false;
                    } else
                    {
                        if (!Settings.IsValidSetting(cache)) return true;
                        wordCount++;
                        isValue = true;
                    }
                }
            }
            return wordCount != Settings.SETTINGS_COUNT;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormSession session = new FormSession(string.Empty);
            session.FormClosed += (x, y) => { Close(); };       //Quickcast to close main Form after user closes the session
            Hide();
            session.ShowDialog();
        }
    }
}
