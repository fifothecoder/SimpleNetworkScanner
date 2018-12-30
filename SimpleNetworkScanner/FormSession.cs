using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleNetworkScanner.Target_Classes;


namespace SimpleNetworkScanner
{
    public partial class FormSession : Form
    {
        private string SESSION_PATH;

        public static List<IPAddress> TARGETS;

        public FormSession(string path)
        {
            InitializeComponent();
            SESSION_PATH = path;
            TARGETS = new List<IPAddress>();
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
            LoadLogs();
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
            try
            {
                using (StreamReader reader = new StreamReader(SESSION_PATH))
                {
                    while(!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        switch(line)
                        {
                            case "@TARGETS_BEGIN":
                                string tar = reader.ReadLine();
                                while(tar != "@TARGETS_END")
                                {
                                    TARGETS.Add(IPAddress.Parse(tar));
                                    tar = reader.ReadLine();
                                }
                                break;
                            default:
                                continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened!" + ex.ToString());
                return false;
            }
            return true;
        }

        private void LoadLogs()
        {
            lbSessionLogs.Items.Add("Session Started : " + DateTime.Now);
        }

        private string GetCurrentSaveString()
        {
            string targets = string.Empty;
            foreach (var tar in TARGETS) { targets += tar.ToString() + Environment.NewLine; }
            return "#SAVE_BEGIN"                    + Environment.NewLine +
                   $"TIME_STAMP"                    + Environment.NewLine +
                   DateTime.Now                     + Environment.NewLine +
                   "@TARGETS_BEGIN"                 + Environment.NewLine +
                   targets + 
                   "@TARGETS_END"                   + Environment.NewLine +
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Session Data|*session", DefaultExt = "session", Title = "Open Session" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FormSession session = new FormSession(openFileDialog.FileName);
                session.FormClosed += (x, y) => { Close(); };       //Quickcast to close main Form after user closes the session
                Hide();
                session.ShowDialog();
            }
            else
            {
                MessageBox.Show("You haven't chosen valid file!");
                //Maybe return new invocation of this method?
            }
        }

        private void addTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddTarget formAdd = new FormAddTarget();
            formAdd.FormClosed += (x, y) => {
                if (formAdd.address != null) lbSessionLogs.Items.Add($"Added adress to targets : {formAdd.address.ToString()}");
                else if(formAdd.range != null && formAdd.range.Count > 0)
                    lbSessionLogs.Items.Add($"Added range of adresses to targets : {formAdd.range[0].ToString()} to {formAdd.range[formAdd.range.Count - 1].ToString()}");
            };
            formAdd.ShowDialog();
        }
    }
}
