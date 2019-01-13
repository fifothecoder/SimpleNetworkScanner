using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleNetworkScanner.Test_Data_Classes;

namespace SimpleNetworkScanner.TCP_Scan_Classes
{

    [Flags] public enum TCPScanType { Brief = 0x0, }

    public partial class FormTCPScan : Form {

        private readonly TCPScanType currentScan;     
        private readonly CancellationTokenSource tokenSource;
        private readonly CancellationToken token;
        private readonly int tcpTimeout;    

        private Task workerTask;
        private List<int> currentPorts;

        public bool completed = false;
        public bool canceled = false;
        public int portsClosed = 0;
        public int portsOpened = 0;

        public int currentIteration = 0;
        

        public FormTCPScan(TCPScanType type)
        {
            InitializeComponent();

            currentScan = type;
            currentPorts = new List<int>();
            tcpTimeout = int.Parse(Settings.GetSetting("TCP_TIMEOUT"));
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
        }

        private void btnStart_Click(object sender, EventArgs e) {
            workerTask = Task.Factory.StartNew(ExecuteTCPScan, token);
            btnStart.Enabled = false;
            btnExit.Enabled = true;
        }

        private void ExecuteTCPScan() {
            lProgress.Invoke( (MethodInvoker) delegate
            {
                lProgress.Text = "Iniciating TCP Scan...";
            });


            token.ThrowIfCancellationRequested();
            if ((currentScan & TCPScanType.Brief) == TCPScanType.Brief) AddPorts(Settings.GetBriefPorts());

            pBar.Invoke((MethodInvoker)delegate {
                pBar.Value = 0;
                pBar.Maximum = currentPorts.Count * FormSession.TARGETS.Count;         
            });

            if ((currentScan & TCPScanType.Brief) == TCPScanType.Brief) {

                Invoke((MethodInvoker) delegate { Text = "Brief TCP Scan"; }); 

                foreach (var target in FormSession.TARGETS) {
                    foreach (var port in currentPorts) {
                        SendTCPRequest(target, port);
                        NextAction();
                    }
                }

            }

            completed = true;
            TCPTestData tcpData = new TCPTestData(TestDataChartType.Pie);
            tcpData.AddData("Open ports", portsOpened);
            tcpData.AddData("Closed ports", portsClosed);
            FormSession.TEST_DATA = tcpData;

            if (!tokenSource.IsCancellationRequested)
                lProgress.Invoke((MethodInvoker) delegate {
                    lProgress.Text = "Scanning completed!";
                    btnExit.Text = "Exit scan";
                });


        }

        private void SendTCPRequest(IPAddress target, int port) {
                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(target, port, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(tcpTimeout);
                    if (!success)
                    {
                        portsClosed++;
                        if (!tokenSource.IsCancellationRequested)
                            lbInfo.Invoke((MethodInvoker)delegate
                            {
                                lbInfo.Items.Add($"{target}:{port}\tis closed/unreachable.");
                            });
                        
                        return;
                    }
                    else
                        portsOpened++;
                    client.EndConnect(result);

                }
            if (!tokenSource.IsCancellationRequested)
                lbInfo.Invoke((MethodInvoker)delegate {
                    lbInfo.Items.Add($"{target}:{port}\tis open.");
                });
        }

        private void NextAction() {
            if (!tokenSource.IsCancellationRequested)
                pBar.Invoke((MethodInvoker) delegate {
                    currentIteration++;
                    pBar.Value = (currentIteration > pBar.Maximum) ? pBar.Maximum : currentIteration;
                    lProgress.Text = $"Scanning port {currentIteration + 1}/{pBar.Maximum}...";
                    lbInfo.TopIndex = lbInfo.Items.Count > 10 ? lbInfo.Items.Count - 1 : 0;
                });
        }

        private void AddPorts(IEnumerable<int> ports) {
            foreach (var port in ports) {
                if(!currentPorts.Contains(port)) currentPorts.Add(port);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!completed) {
                canceled = true;
                LogHandler.AddLog("TCP scan canceled.");
                tokenSource.Cancel(); 
            }
            else LogHandler.AddLog($"TCP scan completed. Open TCP ports : {portsClosed}, Closed/Unreached TCP ports  : {portsOpened}");
            Close();
        }
    }
}
