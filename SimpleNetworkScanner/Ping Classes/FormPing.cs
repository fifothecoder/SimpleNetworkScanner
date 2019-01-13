using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

using SimpleNetworkScanner;
using SimpleNetworkScanner.Test_Data_Classes;

namespace SimpleNetworkScanner.Ping_Classes
{
    [Flags] public enum PingType { Loopback = 0x1, Localhost = 0x2, Dns = 0x4, Targets = 0x8}

    public partial class FormPing : Form {

        private readonly PingType currentType;
        private readonly CancellationTokenSource tokenSource;
        private readonly CancellationToken token;
        private readonly int pingTimeout;

        private const byte LOOPBACK_PING_AMOUNT = 5;
        private const byte LOCALHOST_PING_AMOUNT = 5;
        private const byte DNS_PING_AMOUNT = 5;
        private const byte TARGET_PING_AMOUNT = 3;

        private uint currentIretation = 1;
        private Task pingTask;
        
        public bool completed = false;
        public bool canceled = false;
        public uint pingGood = 0;
        public uint pingBad = 0;
        

        public FormPing(PingType type)
        {
            InitializeComponent();
            btnExit.Enabled = false;
            currentType = type;
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            pingTimeout = int.Parse(Settings.GetSetting("PING_TIMEOUT"));
            Text = "Ping Test";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            pingTask = Task.Factory.StartNew(ExecutePing, token);
            btnExit.Enabled = true;
            btnStart.Enabled = false;
        }

        private void ExecutePing() {

            lProgress.Invoke((MethodInvoker) delegate {
                lProgress.Text = "Initializing ping scan...";
            });
            pBar.Invoke((MethodInvoker) delegate {
                pBar.Maximum = 0;
                if ((PingType.Loopback & currentType) == PingType.Loopback) pBar.Maximum += LOOPBACK_PING_AMOUNT;
                if ((PingType.Localhost & currentType) == PingType.Localhost) pBar.Maximum += LOCALHOST_PING_AMOUNT;
                if ((PingType.Dns & currentType) == PingType.Dns) pBar.Maximum += byte.Parse(Settings.GetSetting("DNS_COUNT")) * DNS_PING_AMOUNT;
                if ((PingType.Targets & currentType) == PingType.Targets) pBar.Maximum += FormSession.TARGETS.Count * TARGET_PING_AMOUNT;
            });

            token.ThrowIfCancellationRequested();

           
            if (!tokenSource.IsCancellationRequested)
                lProgress.Invoke((MethodInvoker) delegate {
                lProgress.Text = $"Pinging {currentIretation}/{pBar.Maximum}...";
            });


            if ((PingType.Loopback & currentType) == PingType.Loopback)
            {
                uint currentGood = 0, currentBad = 0;
                for (int i = 1; i <= LOOPBACK_PING_AMOUNT; i++)
                {
                    PingReply reply = GetPingReply(IPAddress.Loopback);
                    if (reply.Status == IPStatus.Success)
                    {
                        pingGood++;
                        currentGood++;
                    }
                    else
                    {
                        pingBad++;
                        currentBad++;
                    }
                    if (!tokenSource.IsCancellationRequested)
                        lbInfo.Invoke((MethodInvoker)delegate {
                            lbInfo.Items.Add($"Loopback ping {i}/{LOOPBACK_PING_AMOUNT} : {reply.Status.ToString()} \t| Round Trip Time : {reply.RoundtripTime}ms");
                        });

                    if (i != LOOPBACK_PING_AMOUNT) NextAction();
                }
                if (!tokenSource.IsCancellationRequested)
                    LogHandler.AddLog($"Loopback Address ping(s) completed. Successful pings : {currentGood}, Unsuccessful pings : {currentBad}");
            }
            if ((PingType.Localhost & currentType) == PingType.Localhost)
            {
                uint currentGood = 0, currentBad = 0;
                for (int i = 1; i <= LOCALHOST_PING_AMOUNT; i++)
                {
                    PingReply reply = GetPingReply(StaticUtilities.GetLocalIPv4Address());
                    if (reply.Status == IPStatus.Success)
                    {
                        pingGood++;
                        currentGood++;
                    }
                    else
                    {
                        pingBad++;
                        currentBad++;
                    }
                    if (!tokenSource.IsCancellationRequested)
                        lbInfo.Invoke((MethodInvoker)delegate {
                            lbInfo.Items.Add($"Localhost ping {i}/{LOCALHOST_PING_AMOUNT} : {reply.Status.ToString()} \t| Round Trip Time : {reply.RoundtripTime}ms");
                        });
                    if (i != LOCALHOST_PING_AMOUNT) NextAction();
                }
                if (!tokenSource.IsCancellationRequested)
                    LogHandler.AddLog($"Localhost Address ping(s) completed. Successful pings : {currentGood}, Unsuccessful pings : {currentBad}");
            }
            if ((PingType.Dns & currentType) == PingType.Dns)
            {
                uint currentGood = 0, currentBad = 0;
                foreach (var dns in Settings.GetSettingsDnsAddresses())
                {
                    int i = 1;
                    for (; i <= DNS_PING_AMOUNT; i++)
                    {
                        PingReply reply = GetPingReply(dns);
                        if (reply.Status == IPStatus.Success)
                        {
                            pingGood++;
                            currentGood++;
                        }
                        else
                        {
                            pingBad++;
                            currentBad++;
                        }
                        if (!tokenSource.IsCancellationRequested)
                            lbInfo.Invoke((MethodInvoker)delegate {
                                lbInfo.Items.Add($"DNS ping ({dns}) {i}/{DNS_PING_AMOUNT} : {reply.Status.ToString()} \t| Round Trip Time : {reply.RoundtripTime}ms");
                            });
                        if (i != DNS_PING_AMOUNT) NextAction();
                    }
                    if (i != DNS_PING_AMOUNT) NextAction();
                }
                if (!tokenSource.IsCancellationRequested)
                    LogHandler.AddLog($"DNS Addresses ping(s) completed. Successful pings : {currentGood}, Unsuccessful pings : {currentBad}");
            }
            if ((PingType.Targets & currentType) == PingType.Targets)
            {
                uint currentGood = 0, currentBad = 0;
                foreach (var target in FormSession.TARGETS)
                {
                    if (tokenSource.IsCancellationRequested) break;
                    int i = 1;
                    for (; i <= TARGET_PING_AMOUNT; i++) {
                        if (tokenSource.IsCancellationRequested) break;

                        PingReply reply = GetPingReply(target);
                        if (reply.Status == IPStatus.Success)
                        {
                            pingGood++;
                            currentGood++;
                        }
                        else
                        {
                            pingBad++;
                            currentBad++;
                        }
                        if (!tokenSource.IsCancellationRequested)
                            lbInfo.Invoke((MethodInvoker)delegate {
                                lbInfo.Items.Add($"Target ping ({target})\t{i}/{TARGET_PING_AMOUNT} : {reply.Status.ToString()} \t| Round Trip Time : {reply.RoundtripTime}ms");
                            });
                        if (i != TARGET_PING_AMOUNT) NextAction();
                    }
                    if (i != TARGET_PING_AMOUNT) NextAction();
                }

                if (!tokenSource.IsCancellationRequested)
                    LogHandler.AddLog($"Target Addresses ping(s) completed. Successful pings : {currentGood}, Unsuccessful pings : {currentBad}");
            }

            if (!tokenSource.IsCancellationRequested) { 
                lbInfo.Invoke((MethodInvoker) delegate {
                lProgress.Text = "Pings completed";
                btnStart.Enabled = false;
                btnExit.Text = "Exit Test";
            });
                completed = true;
                FormSession.TEST_DATA = GenerateData();
            }
        }

        private PingReply GetPingReply(IPAddress address) {
            Ping ping = new Ping();
            PingReply reply = ping.Send(address, pingTimeout);
            ping.Dispose();
            return reply;
        }

        private void NextAction() {
            currentIretation++;       
            if(!tokenSource.IsCancellationRequested)
                lProgress.Invoke((MethodInvoker) delegate {
                    lProgress.Text = $"Pinging {currentIretation}/{pBar.Maximum}...";
                    pBar.Value = (int)currentIretation > pBar.Maximum ? pBar.Maximum : (int)currentIretation;
                    lbInfo.TopIndex = lbInfo.Items.Count > 10 ? lbInfo.Items.Count - 1 : 0;
                });

            
        }

        private PingTestData GenerateData() {
            PingTestData data = new PingTestData(TestDataChartType.Doughnut);
            data.AddData("Successful pings", (int)pingGood);
            data.AddData("Unsuccessful pings", (int)pingBad);
            return data;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!completed) {
                canceled = true;
                LogHandler.AddLog("Ping scan canceled.");
                tokenSource.Cancel();
            }
            else LogHandler.AddLog($"Ping test completed. Successful pings : {pingGood}, Unsuccessful pings : {pingBad}");
            
            Close();
        }

    }
}
