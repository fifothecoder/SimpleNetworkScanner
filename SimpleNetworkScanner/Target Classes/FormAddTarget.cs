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

        public IPAddress address = null;
        public List<IPAddress> range = null;

        public FormAddTarget()
        {
            InitializeComponent();
            range = new List<IPAddress>();
            address = null;
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
            if(tbSingleIP.Text.TryParseIPv4(out IPAddress _address)) address = _address;
            else
            {
                address = null;
                MessageBox.Show("This is not a valid IP address!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rbSingle.Checked)
            {
                FormSession.TARGETS.Add(address);
                range = null;
            }
            else {
                FormSession.TARGETS.AddRange(range);
                address = null;
            }
            Close();
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
            if (tbRangeIP.Text[tbRangeIP.Text.Length - 1] == '.')                           //Remove '.' at the end if necessary
                tbRangeIP.Text = tbRangeIP.Text.Substring(0, tbRangeIP.Text.Length - 1);

            if ($"{tbRangeIP.Text}.{numFrom.Value}".TryParseIPv4(out IPAddress _address))   //Custom TryParse to check IPv4
                for (int i = (int)numFrom.Value; i <= numTo.Value; i++)
                    range.Add(IPAddress.Parse($"{tbRangeIP.Text}.{i}"));
            else
            {
                range.Clear();
                MessageBox.Show("This is not a valid IP address!");
            }
        }

        private void FormAddTarget_Load(object sender, EventArgs e)
        {

        }
    }
}
