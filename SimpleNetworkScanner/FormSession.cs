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
    public partial class FormSession : Form
    {

        private string SESSION_PATH;

        public FormSession(string path)
        {
            InitializeComponent();
            SESSION_PATH = path;
        }

        private void FormSession_Load(object sender, EventArgs e)
        {
            if(!LoadSettings())
            {
                MessageBox.Show("Error happened while loading settings!");
                Close();
            }
            if (SESSION_PATH != string.Empty)
            {
                if (!LoadData())
                {
                    MessageBox.Show("Error happened while loading session data!");
                    Close();
                }
                Settings.SetSetting("LAST_SAVE", SESSION_PATH);
                Text = SESSION_PATH;
            }


        }

        private bool LoadSettings()
        {
            //Set right resolution
            string resolution = Settings.GetSetting("WIN_SIZE");
            string __width = string.Empty, __height;
            int resIndex = 0;
            for (; resIndex < resolution.Length; resIndex++)
            {
                if (resolution[resIndex] != 'x') __width += resolution[resIndex];
                else break;
            }
            __height = resolution.Substring(resIndex + 1);
            if (!int.TryParse(__width, out int w) || !int.TryParse(__height, out int h)) return false;
            Width = w;
            Height = h;


            return true;
        }

        private bool LoadData()
        {
            return true;
        }

        private string GetCurrentSaveString()
        {
            return "#SAVE_BEGIN"                    + Environment.NewLine +
                   $"Time Stamp : {DateTime.Now}"   + Environment.NewLine +
                   "#SAVE_END";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SESSION_PATH == string.Empty)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Session Data|*session", DefaultExt = "session", Title = "Save Current Session" };
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != string.Empty)
                {

                    using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                    {
                        writer.Write(GetCurrentSaveString());
                    }
                }
                else
                {
                    MessageBox.Show("You need to set the name for the file!");
                    //Maybe return new invocation of this method?
                }
                SESSION_PATH = saveFileDialog.FileName;
                Settings.SetSetting("LAST_SAVE", saveFileDialog.FileName);

            }
            else
            {
                using (StreamWriter writer = new StreamWriter(SESSION_PATH))
                {
                    writer.Write(GetCurrentSaveString());
                }
            }
            Text = SESSION_PATH;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Session Data|*session";
            saveFileDialog.DefaultExt = "session";
            saveFileDialog.Title = "Save Current Session";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != string.Empty)
            {

                using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    writer.Write(GetCurrentSaveString());
                }
            }
            else
            {
                MessageBox.Show("You need to set the name for the file!");
                //Maybe return new invocation of this method?
            }
            SESSION_PATH = saveFileDialog.FileName;
            Settings.SetSetting("LAST_SAVE", saveFileDialog.FileName);
            Text = SESSION_PATH;

        }
    }
}
