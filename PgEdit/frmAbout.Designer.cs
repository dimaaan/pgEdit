﻿namespace PgEdit
{
    partial class frmAbout
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
            this.btnOK = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.llblBugReport = new System.Windows.Forms.LinkLabel();
            this.llbnCheckNewVersion = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(414, 325);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::PgEdit.Properties.Resources.big_logo;
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(190, 275);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(221, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(287, 276);
            this.txtInfo.TabIndex = 0;
            // 
            // llblBugReport
            // 
            this.llblBugReport.AutoSize = true;
            this.llblBugReport.Location = new System.Drawing.Point(12, 335);
            this.llblBugReport.Name = "llblBugReport";
            this.llblBugReport.Size = new System.Drawing.Size(196, 13);
            this.llblBugReport.TabIndex = 2;
            this.llblBugReport.TabStop = true;
            this.llblBugReport.Text = "Feature Request/Bug Report на GitHub";
            this.llblBugReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblBugReport_LinkClicked);
            // 
            // llbnCheckNewVersion
            // 
            this.llbnCheckNewVersion.AutoSize = true;
            this.llbnCheckNewVersion.Location = new System.Drawing.Point(12, 313);
            this.llbnCheckNewVersion.Name = "llbnCheckNewVersion";
            this.llbnCheckNewVersion.Size = new System.Drawing.Size(194, 13);
            this.llbnCheckNewVersion.TabIndex = 1;
            this.llbnCheckNewVersion.TabStop = true;
            this.llbnCheckNewVersion.Text = "Посмотреть новые версии на GitHub";
            this.llbnCheckNewVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbnCheckNewVersion_LinkClicked);
            // 
            // frmAbout
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(520, 360);
            this.Controls.Add(this.llbnCheckNewVersion);
            this.Controls.Add(this.llblBugReport);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PgEdit";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.LinkLabel llblBugReport;
        private System.Windows.Forms.LinkLabel llbnCheckNewVersion;
    }
}