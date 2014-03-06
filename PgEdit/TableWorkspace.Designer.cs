namespace PgEdit
{
    partial class TableWorkspace
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsData = new System.Windows.Forms.BindingSource(this.components);
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.ssData = new System.Windows.Forms.StatusStrip();
            this.tsslRowsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslRowsFiltered = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslOffsetLimit = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.ssData.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsData
            // 
            this.bsData.AllowNew = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.DataSource = this.bsData;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(826, 467);
            this.dgvData.TabIndex = 2;
            // 
            // ssData
            // 
            this.ssData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslRowsCount,
            this.tsslRowsFiltered,
            this.tsslOffsetLimit});
            this.ssData.Location = new System.Drawing.Point(0, 467);
            this.ssData.Name = "ssData";
            this.ssData.Size = new System.Drawing.Size(826, 22);
            this.ssData.SizingGrip = false;
            this.ssData.TabIndex = 3;
            this.ssData.Text = "statusStrip1";
            // 
            // tsslRowsCount
            // 
            this.tsslRowsCount.Name = "tsslRowsCount";
            this.tsslRowsCount.Size = new System.Drawing.Size(260, 17);
            this.tsslRowsCount.Spring = true;
            // 
            // tsslRowsFiltered
            // 
            this.tsslRowsFiltered.Name = "tsslRowsFiltered";
            this.tsslRowsFiltered.Size = new System.Drawing.Size(260, 17);
            this.tsslRowsFiltered.Spring = true;
            // 
            // tsslOffsetLimit
            // 
            this.tsslOffsetLimit.Name = "tsslOffsetLimit";
            this.tsslOffsetLimit.Size = new System.Drawing.Size(260, 17);
            this.tsslOffsetLimit.Spring = true;
            // 
            // TableWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.ssData);
            this.Name = "TableWorkspace";
            this.Size = new System.Drawing.Size(826, 489);
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ssData.ResumeLayout(false);
            this.ssData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.BindingSource bsData;
        private System.Windows.Forms.StatusStrip ssData;
        private System.Windows.Forms.ToolStripStatusLabel tsslRowsCount;
        private System.Windows.Forms.ToolStripStatusLabel tsslRowsFiltered;
        private System.Windows.Forms.ToolStripStatusLabel tsslOffsetLimit;
    }
}
