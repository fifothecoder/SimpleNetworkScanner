namespace SimpleNetworkScanner.Target_Classes
{
    partial class FormAddTarget
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbRangeIP = new System.Windows.Forms.TextBox();
            this.labRangeIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labFrom = new System.Windows.Forms.Label();
            this.numTo = new System.Windows.Forms.NumericUpDown();
            this.numFrom = new System.Windows.Forms.NumericUpDown();
            this.labSingleIP = new System.Windows.Forms.Label();
            this.tbSingleIP = new System.Windows.Forms.TextBox();
            this.rbRange = new System.Windows.Forms.RadioButton();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 55);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(199, 286);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(171, 55);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Target";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbRangeIP);
            this.panel1.Controls.Add(this.labRangeIP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labFrom);
            this.panel1.Controls.Add(this.numTo);
            this.panel1.Controls.Add(this.numFrom);
            this.panel1.Controls.Add(this.labSingleIP);
            this.panel1.Controls.Add(this.tbSingleIP);
            this.panel1.Controls.Add(this.rbRange);
            this.panel1.Controls.Add(this.rbSingle);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 268);
            this.panel1.TabIndex = 2;
            // 
            // tbRangeIP
            // 
            this.tbRangeIP.Location = new System.Drawing.Point(113, 140);
            this.tbRangeIP.MaxLength = 11;
            this.tbRangeIP.Name = "tbRangeIP";
            this.tbRangeIP.Size = new System.Drawing.Size(142, 22);
            this.tbRangeIP.TabIndex = 9;
            this.tbRangeIP.Validating += new System.ComponentModel.CancelEventHandler(this.tbRangeIP_Validating);
            // 
            // labRangeIP
            // 
            this.labRangeIP.AutoSize = true;
            this.labRangeIP.Location = new System.Drawing.Point(23, 140);
            this.labRangeIP.Name = "labRangeIP";
            this.labRangeIP.Size = new System.Drawing.Size(84, 17);
            this.labRangeIP.TabIndex = 8;
            this.labRangeIP.Text = "IP Address :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "To :";
            // 
            // labFrom
            // 
            this.labFrom.AutoSize = true;
            this.labFrom.Location = new System.Drawing.Point(207, 192);
            this.labFrom.Name = "labFrom";
            this.labFrom.Size = new System.Drawing.Size(48, 17);
            this.labFrom.TabIndex = 6;
            this.labFrom.Text = "From :";
            // 
            // numTo
            // 
            this.numTo.Location = new System.Drawing.Point(259, 220);
            this.numTo.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTo.Name = "numTo";
            this.numTo.Size = new System.Drawing.Size(83, 22);
            this.numTo.TabIndex = 5;
            this.numTo.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTo.ValueChanged += new System.EventHandler(this.numTo_ValueChanged);
            // 
            // numFrom
            // 
            this.numFrom.Location = new System.Drawing.Point(259, 191);
            this.numFrom.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.numFrom.Name = "numFrom";
            this.numFrom.Size = new System.Drawing.Size(83, 22);
            this.numFrom.TabIndex = 4;
            this.numFrom.ValueChanged += new System.EventHandler(this.numFrom_ValueChanged);
            // 
            // labSingleIP
            // 
            this.labSingleIP.AutoSize = true;
            this.labSingleIP.Location = new System.Drawing.Point(23, 56);
            this.labSingleIP.Name = "labSingleIP";
            this.labSingleIP.Size = new System.Drawing.Size(84, 17);
            this.labSingleIP.TabIndex = 3;
            this.labSingleIP.Text = "IP Address :";
            this.labSingleIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbSingleIP
            // 
            this.tbSingleIP.Location = new System.Drawing.Point(113, 56);
            this.tbSingleIP.MaxLength = 15;
            this.tbSingleIP.Name = "tbSingleIP";
            this.tbSingleIP.Size = new System.Drawing.Size(230, 22);
            this.tbSingleIP.TabIndex = 2;
            this.tbSingleIP.Validating += new System.ComponentModel.CancelEventHandler(this.tbSingleIP_Validating);
            // 
            // rbRange
            // 
            this.rbRange.AutoSize = true;
            this.rbRange.Location = new System.Drawing.Point(3, 102);
            this.rbRange.Name = "rbRange";
            this.rbRange.Size = new System.Drawing.Size(172, 21);
            this.rbRange.TabIndex = 1;
            this.rbRange.TabStop = true;
            this.rbRange.Text = "Add IP Address Range";
            this.rbRange.UseVisualStyleBackColor = true;
            this.rbRange.CheckedChanged += new System.EventHandler(this.rbRange_CheckedChanged);
            // 
            // rbSingle
            // 
            this.rbSingle.AutoSize = true;
            this.rbSingle.Checked = true;
            this.rbSingle.Location = new System.Drawing.Point(3, 3);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(169, 21);
            this.rbSingle.TabIndex = 0;
            this.rbSingle.TabStop = true;
            this.rbSingle.Text = "Add Single IP Address";
            this.rbSingle.UseVisualStyleBackColor = true;
            this.rbSingle.CheckedChanged += new System.EventHandler(this.rbSingle_CheckedChanged);
            // 
            // FormAddTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Name = "FormAddTarget";
            this.Text = "Add Target";
            this.Load += new System.EventHandler(this.FormAddTarget_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbRange;
        private System.Windows.Forms.RadioButton rbSingle;
        private System.Windows.Forms.Label labSingleIP;
        private System.Windows.Forms.TextBox tbSingleIP;
        private System.Windows.Forms.NumericUpDown numTo;
        private System.Windows.Forms.NumericUpDown numFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labFrom;
        private System.Windows.Forms.Label labRangeIP;
        private System.Windows.Forms.TextBox tbRangeIP;
    }
}