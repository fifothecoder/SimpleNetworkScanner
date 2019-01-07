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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTargetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingLoopbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingLocalhostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingDNSServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingTargetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customPingScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TCPScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.briefTCPScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lookupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSessionLogs = new System.Windows.Forms.ListBox();
            this.chLastAction = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.topMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chLastAction)).BeginInit();
            this.SuspendLayout();
            // 
            // topMenu
            // 
            this.topMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessionToolStripMenuItem,
            this.targetsToolStripMenuItem,
            this.pingToolStripMenuItem,
            this.TCPScanToolStripMenuItem,
            this.lookupToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.topMenu.Size = new System.Drawing.Size(600, 24);
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
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.sessionToolStripMenuItem.Text = "Session";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Enabled = false;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit...";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // targetsToolStripMenuItem
            // 
            this.targetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTargetToolStripMenuItem,
            this.manageTargetsToolStripMenuItem});
            this.targetsToolStripMenuItem.Name = "targetsToolStripMenuItem";
            this.targetsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.targetsToolStripMenuItem.Text = "Targets";
            // 
            // addTargetToolStripMenuItem
            // 
            this.addTargetToolStripMenuItem.Name = "addTargetToolStripMenuItem";
            this.addTargetToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.addTargetToolStripMenuItem.Text = "Add Target...";
            this.addTargetToolStripMenuItem.Click += new System.EventHandler(this.addTargetToolStripMenuItem_Click);
            // 
            // manageTargetsToolStripMenuItem
            // 
            this.manageTargetsToolStripMenuItem.Name = "manageTargetsToolStripMenuItem";
            this.manageTargetsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.manageTargetsToolStripMenuItem.Text = "Manage Targets...";
            this.manageTargetsToolStripMenuItem.Click += new System.EventHandler(this.manageTargetsToolStripMenuItem_Click);
            // 
            // pingToolStripMenuItem
            // 
            this.pingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pingLoopbackToolStripMenuItem,
            this.pingLocalhostToolStripMenuItem,
            this.pingDNSServerToolStripMenuItem,
            this.pingTargetsToolStripMenuItem,
            this.customPingScanToolStripMenuItem});
            this.pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            this.pingToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.pingToolStripMenuItem.Text = "Ping";
            // 
            // pingLoopbackToolStripMenuItem
            // 
            this.pingLoopbackToolStripMenuItem.Name = "pingLoopbackToolStripMenuItem";
            this.pingLoopbackToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pingLoopbackToolStripMenuItem.Text = "Ping Loopback...";
            this.pingLoopbackToolStripMenuItem.Click += new System.EventHandler(this.pingLoopbackToolStripMenuItem_Click);
            // 
            // pingLocalhostToolStripMenuItem
            // 
            this.pingLocalhostToolStripMenuItem.Name = "pingLocalhostToolStripMenuItem";
            this.pingLocalhostToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pingLocalhostToolStripMenuItem.Text = "Ping Localhost...";
            this.pingLocalhostToolStripMenuItem.Click += new System.EventHandler(this.pingLocalhostToolStripMenuItem_Click);
            // 
            // pingDNSServerToolStripMenuItem
            // 
            this.pingDNSServerToolStripMenuItem.Name = "pingDNSServerToolStripMenuItem";
            this.pingDNSServerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pingDNSServerToolStripMenuItem.Text = "Ping DNS Server...";
            this.pingDNSServerToolStripMenuItem.Click += new System.EventHandler(this.pingDNSServerToolStripMenuItem_Click);
            // 
            // pingTargetsToolStripMenuItem
            // 
            this.pingTargetsToolStripMenuItem.Name = "pingTargetsToolStripMenuItem";
            this.pingTargetsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pingTargetsToolStripMenuItem.Text = "Ping Targets...";
            this.pingTargetsToolStripMenuItem.Click += new System.EventHandler(this.pingTargetsToolStripMenuItem_Click);
            // 
            // customPingScanToolStripMenuItem
            // 
            this.customPingScanToolStripMenuItem.Enabled = false;
            this.customPingScanToolStripMenuItem.Name = "customPingScanToolStripMenuItem";
            this.customPingScanToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customPingScanToolStripMenuItem.Text = "Custom Ping Scan...";
            // 
            // TCPScanToolStripMenuItem
            // 
            this.TCPScanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.briefTCPScanToolStripMenuItem});
            this.TCPScanToolStripMenuItem.Name = "TCPScanToolStripMenuItem";
            this.TCPScanToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.TCPScanToolStripMenuItem.Text = "TCP Scan";
            // 
            // briefTCPScanToolStripMenuItem
            // 
            this.briefTCPScanToolStripMenuItem.Name = "briefTCPScanToolStripMenuItem";
            this.briefTCPScanToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.briefTCPScanToolStripMenuItem.Text = "Brief TCP Targets Scan...";
            this.briefTCPScanToolStripMenuItem.Click += new System.EventHandler(this.briefTCPScanToolStripMenuItem_Click);
            // 
            // lookupToolStripMenuItem
            // 
            this.lookupToolStripMenuItem.Enabled = false;
            this.lookupToolStripMenuItem.Name = "lookupToolStripMenuItem";
            this.lookupToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.lookupToolStripMenuItem.Text = "Lookup Addresses";
            // 
            // lbSessionLogs
            // 
            this.lbSessionLogs.FormattingEnabled = true;
            this.lbSessionLogs.Location = new System.Drawing.Point(9, 262);
            this.lbSessionLogs.Margin = new System.Windows.Forms.Padding(2);
            this.lbSessionLogs.Name = "lbSessionLogs";
            this.lbSessionLogs.Size = new System.Drawing.Size(571, 95);
            this.lbSessionLogs.TabIndex = 1;
            // 
            // chLastAction
            // 
            this.chLastAction.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "AreaMain";
            this.chLastAction.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.IsTextAutoFit = false;
            legend1.Name = "MainLegend";
            this.chLastAction.Legends.Add(legend1);
            this.chLastAction.Location = new System.Drawing.Point(12, 27);
            this.chLastAction.Name = "chLastAction";
            this.chLastAction.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "AreaMain";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "MainLegend";
            series1.Name = "MainSeries";
            this.chLastAction.Series.Add(series1);
            this.chLastAction.Size = new System.Drawing.Size(295, 230);
            this.chLastAction.TabIndex = 2;
            this.chLastAction.Text = "chLastAction";
            // 
            // FormSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.chLastAction);
            this.Controls.Add(this.lbSessionLogs);
            this.Controls.Add(this.topMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.topMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormSession";
            this.Text = "Unsaved Session";
            this.Load += new System.EventHandler(this.FormSession_Load);
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chLastAction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TCPScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customPingScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lookupToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chLastAction;
        private System.Windows.Forms.ToolStripMenuItem briefTCPScanToolStripMenuItem;
    }
}