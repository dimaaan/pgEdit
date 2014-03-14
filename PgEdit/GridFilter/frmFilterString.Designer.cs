namespace PgEdit.GridFilter
{
    partial class frmFilterString
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
            this.lblPrompt = new System.Windows.Forms.Label();
            this.lblFiledName = new System.Windows.Forms.Label();
            this.cmbOperand = new System.Windows.Forms.ComboBox();
            this.cmbValue = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panInfo = new System.Windows.Forms.Panel();
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(12, 9);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(118, 13);
            this.lblPrompt.TabIndex = 10;
            this.lblPrompt.Text = "Показать записи где:";
            // 
            // lblFiledName
            // 
            this.lblFiledName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiledName.AutoEllipsis = true;
            this.lblFiledName.Location = new System.Drawing.Point(12, 22);
            this.lblFiledName.Name = "lblFiledName";
            this.lblFiledName.Size = new System.Drawing.Size(342, 23);
            this.lblFiledName.TabIndex = 20;
            this.lblFiledName.Text = "field name";
            this.lblFiledName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbOperand
            // 
            this.cmbOperand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperand.FormattingEnabled = true;
            this.cmbOperand.Location = new System.Drawing.Point(15, 48);
            this.cmbOperand.Name = "cmbOperand";
            this.cmbOperand.Size = new System.Drawing.Size(168, 21);
            this.cmbOperand.TabIndex = 40;
            this.cmbOperand.SelectedValueChanged += new System.EventHandler(this.cmbOperand_SelectedValueChanged);
            // 
            // cmbValue
            // 
            this.cmbValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbValue.FormattingEnabled = true;
            this.cmbValue.Location = new System.Drawing.Point(198, 48);
            this.cmbValue.Name = "cmbValue";
            this.cmbValue.Size = new System.Drawing.Size(156, 21);
            this.cmbValue.TabIndex = 30;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(279, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(198, 130);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 50;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panInfo
            // 
            this.panInfo.Controls.Add(this.lblInfo);
            this.panInfo.Controls.Add(this.picInfo);
            this.panInfo.Location = new System.Drawing.Point(15, 75);
            this.panInfo.Name = "panInfo";
            this.panInfo.Size = new System.Drawing.Size(339, 38);
            this.panInfo.TabIndex = 61;
            // 
            // picInfo
            // 
            this.picInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picInfo.Image = global::PgEdit.Properties.Resources.StatusAnnotations_Information_16xLG;
            this.picInfo.Location = new System.Drawing.Point(0, 0);
            this.picInfo.Name = "picInfo";
            this.picInfo.Size = new System.Drawing.Size(16, 38);
            this.picInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picInfo.TabIndex = 0;
            this.picInfo.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoEllipsis = true;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.Location = new System.Drawing.Point(16, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(323, 38);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "% - любой символ\r\n* - любая последовательность символов";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmFilterString
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(366, 165);
            this.Controls.Add(this.panInfo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbValue);
            this.Controls.Add(this.cmbOperand);
            this.Controls.Add(this.lblFiledName);
            this.Controls.Add(this.lblPrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFilterString";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Фильтр по строкам";
            this.panInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Label lblFiledName;
        private System.Windows.Forms.ComboBox cmbOperand;
        private System.Windows.Forms.ComboBox cmbValue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox picInfo;
    }
}