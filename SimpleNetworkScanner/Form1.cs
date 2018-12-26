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
        private const string APP_DATA_PATH = "settings.sns";


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
            if (File.Exists(APP_DATA_PATH) && !CheckSettingsCorrupted()) return;
                
            btnLast.Enabled = false;
            File.Create(APP_DATA_PATH);

            try
            {
                using (StreamWriter writer = new StreamWriter(APP_DATA_PATH))
                {

                }
            }
            catch (IOException) { throw new Exception("Error occured while creating the settings file!"); }
            catch (Exception) { throw; }
        }

        private bool CheckSettingsCorrupted()
        {
            using (StreamReader reader = new StreamReader(APP_DATA_PATH))
            {
                if (reader.EndOfStream) return false;       //Check if settings aren't empty
                while(reader.EndOfStream)                   //Check for every tuple
                {

                }
            }
            return false;
        }

    }
}
