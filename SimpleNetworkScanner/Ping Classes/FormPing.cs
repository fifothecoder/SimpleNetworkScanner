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
        private readonly CancellationTokenSource pingTokenSource;
        private readonly CancellationToken pingToken;
        private readonly int pingTimeout;

        private const byte LOOPBACK_PING_AMOUNT = 5;
        private const byte LOCALHOST_PING_AMOUNT = 5;
        private const byte DNS_PING_AMOUNT = 5;
        private const byte TARGET_PING_AMOUNT = 3;

        private uint currentIretation = 1;
        private Task<PingReply> pingTask;
        
        public bool completed = false;
        public bool canceled = false;
        public uint pingGood = 0;
        public uint pingBad = 0;
        

        public FormPing(PingType type)
        {
            InitializeComponent();
            btnExit.Enabled = false;
            currentType = type;
            pingTokenSource = new CancellationTokenSource();
            pingToken = pingTokenSource.Token;
            pingTimeout = int.Parse(Settings.GetSetting("PING_TIMEOUT"));
            Text = "Ping Test";
        }

        private void ExecutePing() {

            btnExit.Enabled = true;

            pBar.Maximum = 0;
            
            if ((PingType.Loopback & currentType) == PingType.Loopback) pBar.Maximum += LOOPBACK_PING_AMOUNT;
            if ((PingType.Localhost & currentType) == PingType.Localhost) pBar.Maximum += LOCALHOST_PING_AMOUNT;
            if ((PingType.Dns & currentType) == PingType.Dns) pBar.Maximum += byte.Parse(Settings.GetSetting("DNS_COUNT")) * DNS_PING_AMOUNT;
            if ((PingType.Targets & currentType) == PingType.Targets) pBar.Maximum += FormSession.TARGETS.Count * TARGET_PING_AMOUNT;

            lProgress.Text = $"Pinging {currentIretation}/{pBar.Maximum}...";

            try {
                if ((PingType.Loopback & currentType) == PingType.Loopback) {
                    uint currentGood = 0, currentBad = 0;
                    for (int i = 1; i <= LOOPBACK_PING_AMOUNT; i++) {
                        pingToken.ThrowIfCancellationRequested();
                        pingTask = Task<PingReply>.Factory.StartNew(() => GetPingReply(IPAddress.Loopback), pingToken);
                        if (pingTask.Result.Status == IPStatus.Success) {
                            pingGood++;
                            currentGood++;
                        }
                        else {
                            pingBad++;
                            currentBad++;
                        }
                        lbInfo.Items.Add($"Loopback ping {i}/{LOOPBACK_PING_AMOUNT} : {pingTask.Result.Status.ToString()} \t| Round Trip Time : {pingTask.Result.RoundtripTime}ms");
                        if (i != LOOPBACK_PING_AMOUNT) NextAction();
                    }
                    LogHandler.AddLog($"Loopback Address ping(s) completed. Successful pings : {currentGood}, Unsuccessful pings : {currentBad}");
                }
                if ((PingType.Localhost & currentType) == PingType.Localhost) {
                    uint currentGood = 0, currentBad = 0;
                    for (int i = 1; i <= LOCALHOST_PING_AMOUNT; i++)
                    {
                        pingToken.ThrowIfCancellationRequested();
                        pingTask = Task<PingReply>.Factory.StartNew(() => GetPingReply(StaticUtilities.GetLocalIPv4Address()), pingToken);
                        if (pingTask.Result.Status == IPStatus.Success)
                        {
                            pingGood++;
                            currentGood++;
                        }
                        else
                        {
                            pingBad++;
                            currentBad++;
                        }
                        lbInfo.Items.Add($"Localhost ping {i}/{LOCALHOST_PING_AMOUNT} : {pingTask.Result.Status.ToString()} \t| Round Trip Time : {pingTask.Result.RoundtripTime}ms");
                        if (i != LOCALHOST_PING_AMOUNT) NextAction();
                    }
                    LogHandler.AddLog($"Localhost Address ping(s) completed. Successful pings : {currentGood}, Unsuccessful pings : {currentBad}");
                }
                if ((PingType.Dns & currentType) == PingType.Dns) {
                    uint currentGood = 0, currentBad = 0;
                    foreach (var dns in Settings.GetSettingsDnsAddresses()) {
                        int i = 1;
                        for (; i <= DNS_PING_AMOUNT; i++)
                        {
                            pingToken.ThrowIfCancellationRequested();
                            pingTask = Task<PingReply>.Factory.StartNew(() => GetPingReply(dns), pingToken);
                            if (pingTask.Result.Status == IPStatus.Success)
                            {
                                pingGood++;
                                currentGood++;
                            }
                            else
                            {
                                pingBad++;
                                currentBad++;
                            }
                            lbInfo.Items.Add($"DNS ping ({dns}) {i}/{DNS_PING_AMOUNT} : {pingTask.Result.Status.ToString()} \t| Round Trip Time : {pingTask.Result.RoundtripTime}ms");
                            if (i != DNS_PING_AMOUNT) NextAction();
                        }
                        if (i != DNS_PING_AMOUNT) NextAction();
                    }    
                    LogHandler.AddLog($"DNS Addresses ping(s) completed. Successful pings : {currentGood}, Unsuccessful pings : {currentBad}");
                }
                if ((PingType.Targets & currentType) == PingType.Targets) {
                    uint currentGood = 0, currentBad = 0;
                    foreach (var target in FormSession.TARGETS) {
                        int i = 1;
                        for (; i <= TARGET_PING_AMOUNT; i++)
                        {
                            pingToken.ThrowIfCancellationRequested();
                            pingTask = Task<PingReply>.Factory.StartNew(() => GetPingReply(target), pingToken);
                            if (pingTask.Result.Status == IPStatus.Success)
                            {
                                pingGood++;
                                currentGood++;
                            }
                            else
                            {
                                pingBad++;
                                currentBad++;
                            }
                            lbInfo.Items.Add($"Target ping ({target})\t{i}/{TARGET_PING_AMOUNT} : {pingTask.Result.Status.ToString()} \t| Round Trip Time : {pingTask.Result.RoundtripTime}ms");
                            if (i != TARGET_PING_AMOUNT) NextAction();
                        }
                        if (i != TARGET_PING_AMOUNT) NextAction();
                    }
                    LogHandler.AddLog($"Target Addresses ping(s) completed. Successful pings : {currentGood}, Unsuccessful pings : {currentBad}");
                }
            }
            catch (OperationCanceledException) {
                lbInfo.Items.Add("Test Canceled!");
                LogHandler.AddLog("Ping test canceled.");
                canceled = true;
                Close();
            }
            //catch (Exception ex) { lbInfo.Items.Add($"Exception caught! {ex}"); }

            lProgress.Text = "Pings completed";
            btnStart.Enabled = false;
            btnExit.Text = "Exit Test";
            completed = true;
            FormSession.TEST_DATA = GenerateData();
        }

        private PingReply GetPingReply(IPAddress address) {
            Ping ping = new Ping();
            PingReply reply = ping.Send(address, pingTimeout);
            ping.Dispose();
            return reply;
        }

        private void NextAction() {
            currentIretation++;
            pBar.Value = (int)currentIretation > pBar.Maximum ? pBar.Maximum : (int)currentIretation; 
            lProgress.Text = $"Pinging {currentIretation}/{pBar.Maximum}...";    
            lbInfo.TopIndex = lbInfo.Items.Count > 10 ? lbInfo.Items.Count - 1 : 0;
        }

        private PingTestData GenerateData() {
            PingTestData data = new PingTestData(TestDataChartType.Doughnut);
            data.AddData("Successful pings", (int)pingGood);
            data.AddData("Unsuccessful pings", (int)pingBad);
            return data;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ExecutePing();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!completed) {
                pingTokenSource.Cancel();
            }
            else {
                LogHandler.AddLog($"Ping test completed. Successful pings : {pingGood}, Unsuccessful pings : {pingBad}");
                Close();
            }
        }
    }
}
