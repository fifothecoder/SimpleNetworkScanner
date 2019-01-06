namespace SimpleNetworkScanner.Target_Classes
{
    partial class FormManageTargets
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
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnAddTarget = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.lbTargets = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(315, 10);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(131, 49);
            this.btnRemoveAll.TabIndex = 2;
            this.btnRemoveAll.Text = "Remove All Targets";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAddTarget
            // 
            this.btnAddTarget.Location = new System.Drawing.Point(9, 10);
            this.btnAddTarget.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddTarget.Name = "btnAddTarget";
            this.btnAddTarget.Size = new System.Drawing.Size(131, 49);
            this.btnAddTarget.TabIndex = 0;
            this.btnAddTarget.Text = "Add Another Target";
            this.btnAddTarget.UseVisualStyleBackColor = true;
            this.btnAddTarget.Click += new System.EventHandler(this.btnAddTarget_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(145, 10);
            this.btnRemoveSelected.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(166, 49);
            this.btnRemoveSelected.TabIndex = 1;
            this.btnRemoveSelected.Text = "Remove Selected Target(s)";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // lbTargets
            // 
            this.lbTargets.FormattingEnabled = true;
            this.lbTargets.Location = new System.Drawing.Point(9, 63);
            this.lbTargets.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbTargets.Name = "lbTargets";
            this.lbTargets.Size = new System.Drawing.Size(428, 381);
            this.lbTargets.Sorted = true;
            this.lbTargets.TabIndex = 3;
            // 
            // FormManageTargets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 449);
            this.Controls.Add(this.lbTargets);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.btnAddTarget);
            this.Controls.Add(this.btnRemoveAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormManageTargets";
            this.Text = "FormManageTargets";
            this.Load += new System.EventHandler(this.FormManageTargets_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnAddTarget;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.ListBox lbTargets;
    }
}