using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SimpleNetworkScanner.Ping_Classes;
using SimpleNetworkScanner.Target_Classes;
using SimpleNetworkScanner.TCP_Scan_Classes;
using SimpleNetworkScanner.Test_Data_Classes;


namespace SimpleNetworkScanner
{

    public partial class FormSession : Form
    {
        private string _SESSION_PATH;

        public static ITestData TEST_DATA;
        public static List<IPAddress> TARGETS;


        public FormSession(string path)
        {
            InitializeComponent();
            _SESSION_PATH = path;
            TARGETS = new List<IPAddress>();
            TEST_DATA = null;
        }

        private void FormSession_Load(object sender, EventArgs e)
        {
            LoadLogs();
            if (!LoadSettings())
            {
                MessageBox.Show("Error happened while loading settings!");
                Close();
            }
            if (_SESSION_PATH != string.Empty)
            {
                if (!LoadData())
                {
                    MessageBox.Show("Error happened while loading session data!");
                    Close();
                }
                Settings.SetSetting("LAST_SAVE", _SESSION_PATH);
                Text = _SESSION_PATH;
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
            try
            {
                using (StreamReader reader = new StreamReader(_SESSION_PATH))
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
            LogHandler.AddLog("Session Started : " + DateTime.Now);
            RefreshLogs();
        }

        private void RefreshLogs()
        {
            for (int i = lbSessionLogs.Items.Count; i < LogHandler.LOG_CACHE.Count; i++)    //Update logs
                lbSessionLogs.Items.Add(LogHandler.LOG_CACHE[i]);
        }

        private void RefreshGraph() {
            if (TEST_DATA == null) chLastAction.Enabled = false;
            else {
                switch (TEST_DATA.GetChartType()) {
                    case TestDataChartType.Pie:
                        chLastAction.Series[0].ChartType = SeriesChartType.Pie;
                        break;
                    case TestDataChartType.Column:
                        chLastAction.Series[0].ChartType = SeriesChartType.Column;
                        break;
                    case TestDataChartType.Doughnut:
                        chLastAction.Series[0].ChartType = SeriesChartType.Doughnut;
                        break;
                }

                chLastAction.Series[0].Points.Clear();

                foreach (var record in TEST_DATA.GetChartData()) {
                    if (record.Value == 0) continue;
                    DataPoint point = new DataPoint(0, record.Value);
                    point.LegendText = record.Key;
                    point.Label = record.Value.ToString();
                    chLastAction.Series[0].Points.Add(point);
                }
                
                chLastAction.Enabled = true;
            }
        }

        private static string GetCurrentSaveString()
        {
            //Compose the parts here
            string targets = string.Empty;
            foreach (var tar in TARGETS) { targets += tar + Environment.NewLine; }

            //Actual return string
            return "#SAVE_BEGIN"                    + Environment.NewLine +
                   $"TIME_STAMP"                    + Environment.NewLine +
                   DateTime.Now                     + Environment.NewLine +
                   "@TARGETS_BEGIN"                 + Environment.NewLine +
                   targets + 
                   "@TARGETS_END"                   + Environment.NewLine +
                   "#SAVE_END";
        }

        private void EnableSavePrompt()
        {
            if (Text[0] != '*') Text = '*' + Text;

            FormClosing += ShowPrompt();
            //Actually activate the prompt upon exit
        }

        private void DisableSavePrompt()
        {
            if (Text[0] == '*') Text = Text.Substring(1);

            FormClosing -= ShowPrompt();
            //Disable the prompt upon exit
        }

        private FormClosingEventHandler ShowPrompt() {
            return (sender, args) => {
                var result = MessageBox.Show("There are unsaved changes. Do you wish to exit without saving?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                args.Cancel = result == DialogResult.No;

            };
        }

        #region Session Toolstrip

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SESSION_PATH == string.Empty)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Session ChartData|*session", DefaultExt = "session", Title = "Save Current Session" };
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != string.Empty)
                {

                    using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                    {
                        writer.Write(GetCurrentSaveString());
                    }
                    DisableSavePrompt();
                }
                else
                {
                    MessageBox.Show("You need to set the name for the file!");
                    //Maybe return new invocation of this method?
                }
                if(saveFileDialog.FileName != string.Empty) Text = _SESSION_PATH = saveFileDialog.FileName;
                Settings.SetSetting("LAST_SAVE", saveFileDialog.FileName);

            }
            else
            {
                using (StreamWriter writer = new StreamWriter(_SESSION_PATH))
                {
                    writer.Write(GetCurrentSaveString());
                }
                DisableSavePrompt();
                Text = _SESSION_PATH;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Session ChartData|*session";
            saveFileDialog.DefaultExt = "session";
            saveFileDialog.Title = "Save Current Session";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != string.Empty)
            {

                using (StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    writer.Write(GetCurrentSaveString());
                }
                _SESSION_PATH = saveFileDialog.FileName;
                Settings.SetSetting("LAST_SAVE", saveFileDialog.FileName);
                Text = _SESSION_PATH;
            }
            else
            {
                MessageBox.Show("You need to set the name for the file!");
                //Maybe return new invocation of this method?
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Session ChartData|*session", DefaultExt = "session", Title = "Open Session" };
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { Close(); }

        #endregion

        #region Target Toolstrip

        private void addTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddTarget formAdd = new FormAddTarget();
            formAdd.FormClosed += (x, y) => {
                RefreshLogs();
                if (formAdd.CHANGES_HAPPENED) EnableSavePrompt();
            };
            formAdd.ShowDialog();
        }

        private void manageTargetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageTargets formManageTargets = new FormManageTargets();
            formManageTargets.FormClosed += (x, y) => {
                RefreshLogs();
                if (formManageTargets.CHANGES_HAPPENED) EnableSavePrompt();
            };
            formManageTargets.ShowDialog();
        }

        #endregion

        #region Ping Toolstrip
        private void pingLoopbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPing formPing = new FormPing(PingType.Loopback);
            formPing.FormClosed += (x, y) => {
                RefreshLogs();
                RefreshGraph();
                if (formPing.completed)
                {
                    EnableSavePrompt();
                }
            };
            formPing.ShowDialog();
        }

        private void pingLocalhostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPing formPing = new FormPing(PingType.Localhost);
            formPing.FormClosed += (x, y) => {
                RefreshLogs();
                RefreshGraph();
                if (formPing.completed)
                {
                    EnableSavePrompt();
                }
            };
            formPing.ShowDialog();
        }

        private void pingDNSServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPing formPing = new FormPing(PingType.Dns);
            formPing.FormClosed += (x, y) => {
                RefreshLogs();
                RefreshGraph();
                if (formPing.completed)
                {
                    EnableSavePrompt();
                }
            };
            formPing.ShowDialog();
        }

        private void pingTargetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPing formPing = new FormPing(PingType.Targets);
            formPing.FormClosed += (x, y) => {
                RefreshLogs();
                RefreshGraph();
                if (formPing.completed)
                {
                    EnableSavePrompt();
                }
            };
            formPing.ShowDialog();
        }
        #endregion

        #region TCP Toolstrip

        private void briefTCPScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTCPScan formTCP = new FormTCPScan(TCPScanType.Brief);
            formTCP.FormClosed += (x, y) => {
                RefreshLogs();
                RefreshGraph();
                if (formTCP.completed)
                {
                    EnableSavePrompt();
                }
            };
            formTCP.ShowDialog();
        }

        #endregion


    }
}
