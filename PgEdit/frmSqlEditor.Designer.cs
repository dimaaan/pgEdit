namespace PgEdit
{
    partial class frmSqlEditor
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.txtSqlExpr = new System.Windows.Forms.TextBox();
            this.tcResults = new System.Windows.Forms.TabControl();
            this.tpSqlResult = new System.Windows.Forms.TabPage();
            this.dgvSqlResult = new System.Windows.Forms.DataGridView();
            this.tpError = new System.Windows.Forms.TabPage();
            this.txtSqlError = new System.Windows.Forms.TextBox();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tssbRun = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiRunSelected = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tcResults.SuspendLayout();
            this.tpSqlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSqlResult)).BeginInit();
            this.tpError.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 25);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.txtSqlExpr);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.tcResults);
            this.scMain.Size = new System.Drawing.Size(784, 536);
            this.scMain.SplitterDistance = 203;
            this.scMain.TabIndex = 0;
            // 
            // txtSqlExpr
            // 
            this.txtSqlExpr.AcceptsTab = true;
            this.txtSqlExpr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSqlExpr.Location = new System.Drawing.Point(0, 0);
            this.txtSqlExpr.Multiline = true;
            this.txtSqlExpr.Name = "txtSqlExpr";
            this.txtSqlExpr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSqlExpr.Size = new System.Drawing.Size(784, 203);
            this.txtSqlExpr.TabIndex = 0;
            this.txtSqlExpr.WordWrap = false;
            this.txtSqlExpr.TextChanged += new System.EventHandler(this.txtSqlExpr_TextChanged);
            this.txtSqlExpr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxes_KeyDown);
            // 
            // tcResults
            // 
            this.tcResults.Controls.Add(this.tpSqlResult);
            this.tcResults.Controls.Add(this.tpError);
            this.tcResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcResults.Location = new System.Drawing.Point(0, 0);
            this.tcResults.Name = "tcResults";
            this.tcResults.SelectedIndex = 0;
            this.tcResults.Size = new System.Drawing.Size(784, 329);
            this.tcResults.TabIndex = 1;
            // 
            // tpSqlResult
            // 
            this.tpSqlResult.Controls.Add(this.dgvSqlResult);
            this.tpSqlResult.Location = new System.Drawing.Point(4, 22);
            this.tpSqlResult.Name = "tpSqlResult";
            this.tpSqlResult.Padding = new System.Windows.Forms.Padding(3);
            this.tpSqlResult.Size = new System.Drawing.Size(776, 303);
            this.tpSqlResult.TabIndex = 0;
            this.tpSqlResult.Text = "Результат запроса";
            this.tpSqlResult.UseVisualStyleBackColor = true;
            // 
            // dgvSqlResult
            // 
            this.dgvSqlResult.AllowUserToAddRows = false;
            this.dgvSqlResult.AllowUserToDeleteRows = false;
            this.dgvSqlResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSqlResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSqlResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSqlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSqlResult.Location = new System.Drawing.Point(3, 3);
            this.dgvSqlResult.Name = "dgvSqlResult";
            this.dgvSqlResult.ReadOnly = true;
            this.dgvSqlResult.RowHeadersVisible = false;
            this.dgvSqlResult.Size = new System.Drawing.Size(770, 297);
            this.dgvSqlResult.TabIndex = 0;
            // 
            // tpError
            // 
            this.tpError.Controls.Add(this.txtSqlError);
            this.tpError.Location = new System.Drawing.Point(4, 22);
            this.tpError.Name = "tpError";
            this.tpError.Padding = new System.Windows.Forms.Padding(3);
            this.tpError.Size = new System.Drawing.Size(776, 303);
            this.tpError.TabIndex = 1;
            this.tpError.Text = "Ошибка";
            this.tpError.UseVisualStyleBackColor = true;
            // 
            // txtSqlError
            // 
            this.txtSqlError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSqlError.Location = new System.Drawing.Point(3, 3);
            this.txtSqlError.Multiline = true;
            this.txtSqlError.Name = "txtSqlError";
            this.txtSqlError.ReadOnly = true;
            this.txtSqlError.Size = new System.Drawing.Size(770, 297);
            this.txtSqlError.TabIndex = 0;
            this.txtSqlError.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxes_KeyDown);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbRun});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(784, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // tssbRun
            // 
            this.tssbRun.AutoToolTip = false;
            this.tssbRun.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRunSelected});
            this.tssbRun.Enabled = false;
            this.tssbRun.Image = global::PgEdit.Properties.Resources.RunSql_16xLG;
            this.tssbRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbRun.Name = "tssbRun";
            this.tssbRun.Size = new System.Drawing.Size(101, 22);
            this.tssbRun.Text = "Выполнить";
            this.tssbRun.ButtonClick += new System.EventHandler(this.tssbRun_ButtonClick);
            this.tssbRun.DropDownOpening += new System.EventHandler(this.tssbRun_DropDownOpening);
            // 
            // tsmiRunSelected
            // 
            this.tsmiRunSelected.Name = "tsmiRunSelected";
            this.tsmiRunSelected.Size = new System.Drawing.Size(206, 22);
            this.tsmiRunSelected.Text = "Выполнить выделенное";
            this.tsmiRunSelected.Click += new System.EventHandler(this.tsmiRunSelected_Click);
            // 
            // frmSqlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.tsMain);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "frmSqlEditor";
            this.ShowIcon = false;
            this.Text = "Редактор SQL";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.tcResults.ResumeLayout(false);
            this.tpSqlResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSqlResult)).EndInit();
            this.tpError.ResumeLayout(false);
            this.tpError.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TextBox txtSqlExpr;
        private System.Windows.Forms.DataGridView dgvSqlResult;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.TabControl tcResults;
        private System.Windows.Forms.TabPage tpSqlResult;
        private System.Windows.Forms.TabPage tpError;
        private System.Windows.Forms.TextBox txtSqlError;
        private System.Windows.Forms.ToolStripSplitButton tssbRun;
        private System.Windows.Forms.ToolStripMenuItem tsmiRunSelected;
    }
}