namespace PgEdit.GridFilter
{
    partial class frmFilterNumber
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbOperand = new System.Windows.Forms.ComboBox();
            this.lblFiledName = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(198, 131);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(279, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbOperand
            // 
            this.cmbOperand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperand.FormattingEnabled = true;
            this.cmbOperand.Location = new System.Drawing.Point(15, 49);
            this.cmbOperand.Name = "cmbOperand";
            this.cmbOperand.Size = new System.Drawing.Size(168, 21);
            this.cmbOperand.TabIndex = 3;
            // 
            // lblFiledName
            // 
            this.lblFiledName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiledName.AutoEllipsis = true;
            this.lblFiledName.Location = new System.Drawing.Point(12, 23);
            this.lblFiledName.Name = "lblFiledName";
            this.lblFiledName.Size = new System.Drawing.Size(342, 23);
            this.lblFiledName.TabIndex = 1;
            this.lblFiledName.Text = "field name";
            this.lblFiledName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(12, 10);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(118, 13);
            this.lblPrompt.TabIndex = 0;
            this.lblPrompt.Text = "Показать записи где:";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(198, 49);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(156, 20);
            this.txtValue.TabIndex = 2;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // frmFilterNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 165);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbOperand);
            this.Controls.Add(this.lblFiledName);
            this.Controls.Add(this.lblPrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFilterNumber";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Фильтр по числам";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbOperand;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Label lblFiledName;
        private System.Windows.Forms.TextBox txtValue;
    }
}