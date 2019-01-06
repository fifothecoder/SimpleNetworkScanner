using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleNetworkScanner.Target_Classes
{
    public partial class FormAddTarget : Form
    {

        public bool CHANGES_HAPPENED = false;
        public IPAddress IP_ADDRESS = null;
        public List<IPAddress> IP_RANGE = null;

        public FormAddTarget()
        {
            InitializeComponent();
            IP_RANGE = new List<IPAddress>();
            IP_ADDRESS = null;
            RefreshUI();
        }

        private void RefreshUI()
        {
            labSingleIP.Enabled = rbSingle.Checked;
            tbSingleIP.Enabled = rbSingle.Checked;

            labRangeIP.Enabled = rbRange.Checked;
            tbRangeIP.Enabled = rbRange.Checked;
            numFrom.Enabled = rbRange.Checked;
            numTo.Enabled = rbRange.Checked;
        }

        private void tbSingleIP_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rbSingle.Checked)
            {
                if (tbSingleIP.Text.TryParseIPv4(out IPAddress _address)) {
                    if (!FormSession.TARGETS.Contains(_address))
                    {
                        IP_ADDRESS = _address;
                        FormSession.TARGETS.Add(IP_ADDRESS);
                        IP_RANGE = null;
                        LogHandler.AddLog($"Added address to targets : {IP_ADDRESS.ToString()}");
                        CHANGES_HAPPENED = true;
                        Close();
                    }
                    else MessageBox.Show("This IP is already on the target list!");
                }
                else
                {
                    IP_ADDRESS = null;
                    MessageBox.Show("This is not a valid IP address!");
                }
                
            }
            else {
                if (tbRangeIP.Text[tbRangeIP.Text.Length - 1] == '.')                           //Remove '.' at the end if necessary
                    tbRangeIP.Text = tbRangeIP.Text.Substring(0, tbRangeIP.Text.Length - 1);

                if ($"{tbRangeIP.Text}.{numFrom.Value}".TryParseIPv4(out IPAddress _address))   //Custom TryParse to check IPv4
                {
                    for (int i = (int)numFrom.Value; i <= numTo.Value; i++)
                    {
                        IPAddress ip = IPAddress.Parse($"{tbRangeIP.Text}.{i}");
                        if (!FormSession.TARGETS.Contains(ip))
                        {
                            IP_RANGE.Add(ip);
                            continue;
                        }

                        //What if range contains one of the already added targets

                        DialogResult result = MessageBox.Show($"IP address {ip.ToString()} is already on the list.", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                        if (result == DialogResult.Retry) i--;
                        else if (result == DialogResult.Ignore) continue;
                        else return;
                    }

                    FormSession.TARGETS.AddRange(IP_RANGE);
                    LogHandler.AddLog($"Added range of addresses to targets : {IP_RANGE[0].ToString()} to {IP_RANGE[IP_RANGE.Count - 1].ToString()}");
                    CHANGES_HAPPENED = true;
                    IP_ADDRESS = null;
                    Close();
                }
                else
                {
                    IP_RANGE.Clear();
                    MessageBox.Show("This is not a valid IP range! (Use in form of XYZ.XYZ.XYZ)");
                }
            }
        }

        private void rbSingle_CheckedChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void rbRange_CheckedChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void numFrom_ValueChanged(object sender, EventArgs e)
        {
            if (numFrom.Value > numTo.Value) numFrom.Value = numTo.Value - 1;
        }

        private void numTo_ValueChanged(object sender, EventArgs e)
        {
            if (numTo.Value < numFrom.Value) numTo.Value = numFrom.Value + 1;
        }

        private void tbRangeIP_Validating(object sender, CancelEventArgs e)
        {
            
        }
    }
}
