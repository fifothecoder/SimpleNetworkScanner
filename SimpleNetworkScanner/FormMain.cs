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
                btnLast.Enabled = false;
                if(Settings.HasKey("LAST_SAVE"))
                {
                    btnLast.Enabled = true;
                    string fileLoc = " (";
                    fileLoc += (Settings.GetSetting("LAST_SAVE").Length > 50) ? "..." + Settings.GetSetting("LAST_SAVE").Substring(Settings.GetSetting("LAST_SAVE").Length - 47) 
                        : Settings.GetSetting("LAST_SAVE");        //Set text to show to max 52 chars
                    btnLast.Text += fileLoc + ")";   
                }
               
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
                    writer.WriteLine("DNS_COUNT 2");
                    writer.WriteLine("DNS_RECORD_1 8.8.8.8");
                    writer.WriteLine("DNS_RECORD_2 8.8.4.4");
                    writer.WriteLine("PING_TIMEOUT 1500");
                }
            }
            catch (IOException) { throw new Exception("Error occured while creating the settings file!"); }
        }

        private bool CheckSettingsCorrupted()
        {
            int wordCount = 0;
            using (StreamReader reader = new StreamReader(Settings.SETTINGS_PATH))
            {
                bool isValue = false;
                
                while(!reader.EndOfStream)                   //Check for every tuple
                {
                    string cache = (isValue) ? reader.ReadLine().Trim() : reader.ReadWord();
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

        private void btnLast_Click(object sender, EventArgs e)
        {
            FormSession session = new FormSession(Settings.GetSetting("LAST_SAVE"));
            session.FormClosed += (x, y) => { Close(); };       //Quickcast to close main Form after user closes the session
            Hide();
            session.ShowDialog();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Session Data|*session", DefaultExt = "session", Title = "Open Session" };
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FormSession session = new FormSession(openFileDialog.FileName);
                session.FormClosed += (x, y) => { Close(); };       //Quickcast to close main Form after user closes the session
                Hide();
                session.ShowDialog();
            } else
            {
                MessageBox.Show("You haven't chosen valid file!");
                //Maybe return new invocation of this method?
            }

        }
    }
}
