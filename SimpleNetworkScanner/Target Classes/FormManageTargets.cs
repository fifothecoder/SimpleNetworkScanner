using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleNetworkScanner.Target_Classes
{
    public partial class FormManageTargets : Form
    {

        public bool CHANGES_HAPPENED = false;

        public FormManageTargets()
        {
            InitializeComponent();
        }

        private void FormManageTargets_Load(object sender, EventArgs e)
        {
            RefreshList();
            Text = "Manage targets";
        }

        private void RefreshList()
        {
            lbTargets.Items.Clear();
            lbTargets.Enabled = FormSession.TARGETS.Count != 0;
            if (FormSession.TARGETS.Count == 0) lbTargets.Items.Add("No targets found");
            else foreach (var tar in FormSession.TARGETS) lbTargets.Items.Add(tar.ToString());
        }

        private void btnAddTarget_Click(object sender, EventArgs e)
        {
            FormAddTarget formAdd = new FormAddTarget();
            formAdd.FormClosed += (x, y) => {
                RefreshList();
                CHANGES_HAPPENED = formAdd.CHANGES_HAPPENED;
            };
            formAdd.ShowDialog();
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to remove {lbTargets.SelectedItems.Count} targets?", "Remove Selected Targets", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (var tar in lbTargets.SelectedItems)
                {
                    FormSession.TARGETS.Remove(IPAddress.Parse(tar.ToString()));
                    LogHandler.AddLog($"Removed target {tar.ToString()}");
                }
                RefreshList();
                CHANGES_HAPPENED = true;
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to remove ALL ({lbTargets.Items.Count}) targets?", "Remove ALL Targets", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (var tar in lbTargets.Items) FormSession.TARGETS.Remove(IPAddress.Parse(tar.ToString()));
                LogHandler.AddLog("Removed ALL targets");
                RefreshList();
                CHANGES_HAPPENED = true;
            }
        }
    }
}
