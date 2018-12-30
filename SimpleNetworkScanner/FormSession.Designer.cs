namespace SimpleNetworkScanner
{
    partial class FormSession
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingLoopbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingLocalhostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingDNSServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingTargetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTargetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSessionLogs = new System.Windows.Forms.ListBox();
            this.topMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenu
            // 
            this.topMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessionToolStripMenuItem,
            this.pingToolStripMenuItem,
            this.targetsToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(800, 28);
            this.topMenu.TabIndex = 0;
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.sessionToolStripMenuItem.Text = "Session";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.settingsToolStripMenuItem.Text = "Settings...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.exitToolStripMenuItem.Text = "Exit...";
            // 
            // pingToolStripMenuItem
            // 
            this.pingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pingLoopbackToolStripMenuItem,
            this.pingLocalhostToolStripMenuItem,
            this.pingDNSServerToolStripMenuItem,
            this.pingTargetsToolStripMenuItem});
            this.pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            this.pingToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.pingToolStripMenuItem.Text = "Ping";
            // 
            // pingLoopbackToolStripMenuItem
            // 
            this.pingLoopbackToolStripMenuItem.Name = "pingLoopbackToolStripMenuItem";
            this.pingLoopbackToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.pingLoopbackToolStripMenuItem.Text = "Ping Loopback...";
            // 
            // pingLocalhostToolStripMenuItem
            // 
            this.pingLocalhostToolStripMenuItem.Name = "pingLocalhostToolStripMenuItem";
            this.pingLocalhostToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.pingLocalhostToolStripMenuItem.Text = "Ping Localhost...";
            // 
            // pingDNSServerToolStripMenuItem
            // 
            this.pingDNSServerToolStripMenuItem.Name = "pingDNSServerToolStripMenuItem";
            this.pingDNSServerToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.pingDNSServerToolStripMenuItem.Text = "Ping DNS Server";
            // 
            // pingTargetsToolStripMenuItem
            // 
            this.pingTargetsToolStripMenuItem.Name = "pingTargetsToolStripMenuItem";
            this.pingTargetsToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.pingTargetsToolStripMenuItem.Text = "Ping Targets";
            // 
            // targetsToolStripMenuItem
            // 
            this.targetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTargetToolStripMenuItem,
            this.manageTargetsToolStripMenuItem});
            this.targetsToolStripMenuItem.Name = "targetsToolStripMenuItem";
            this.targetsToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.targetsToolStripMenuItem.Text = "Targets";
            // 
            // addTargetToolStripMenuItem
            // 
            this.addTargetToolStripMenuItem.Name = "addTargetToolStripMenuItem";
            this.addTargetToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.addTargetToolStripMenuItem.Text = "Add Target...";
            this.addTargetToolStripMenuItem.Click += new System.EventHandler(this.addTargetToolStripMenuItem_Click);
            // 
            // manageTargetsToolStripMenuItem
            // 
            this.manageTargetsToolStripMenuItem.Name = "manageTargetsToolStripMenuItem";
            this.manageTargetsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.manageTargetsToolStripMenuItem.Text = "Manage Targets...";
            // 
            // lbSessionLogs
            // 
            this.lbSessionLogs.FormattingEnabled = true;
            this.lbSessionLogs.ItemHeight = 16;
            this.lbSessionLogs.Location = new System.Drawing.Point(12, 322);
            this.lbSessionLogs.Name = "lbSessionLogs";
            this.lbSessionLogs.Size = new System.Drawing.Size(776, 116);
            this.lbSessionLogs.TabIndex = 1;
            // 
            // FormSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbSessionLogs);
            this.Controls.Add(this.topMenu);
            this.MainMenuStrip = this.topMenu;
            this.Name = "FormSession";
            this.Text = "Unsaved Session";
            this.Load += new System.EventHandler(this.FormSession_Load);
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ListBox lbSessionLogs;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingLoopbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingLocalhostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingDNSServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingTargetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem targetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTargetsToolStripMenuItem;
    }
}