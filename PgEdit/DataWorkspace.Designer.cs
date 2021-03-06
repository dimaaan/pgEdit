﻿namespace PgEdit
{
    partial class DataWorkspace
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cmsData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.bsData = new System.Windows.Forms.BindingSource(this.components);
            this.ssData = new System.Windows.Forms.StatusStrip();
            this.tsslRowsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslRowsFiltered = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSort = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslOffsetLimit = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFilterExpr = new System.Windows.Forms.Label();
            this.panFilters = new System.Windows.Forms.Panel();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tsData = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.cmsData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).BeginInit();
            this.ssData.SuspendLayout();
            this.panFilters.SuspendLayout();
            this.tsData.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.ContextMenuStrip = this.cmsData;
            this.dgvData.DataSource = this.bsData;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 25);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(640, 400);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 1;
            this.dgvData.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvData_ColumnAdded);
            this.dgvData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvData_DataError);
            // 
            // cmsData
            // 
            this.cmsData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefresh});
            this.cmsData.Name = "cmsData";
            this.cmsData.Size = new System.Drawing.Size(148, 26);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Image = global::PgEdit.Properties.Resources.refresh_16xLG;
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmiRefresh.Size = new System.Drawing.Size(147, 22);
            this.tsmiRefresh.Text = "Обновить";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // bsData
            // 
            this.bsData.AllowNew = false;
            // 
            // ssData
            // 
            this.ssData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslRowsCount,
            this.tsslRowsFiltered,
            this.tsslSort,
            this.tsslOffsetLimit});
            this.ssData.Location = new System.Drawing.Point(0, 458);
            this.ssData.Name = "ssData";
            this.ssData.Size = new System.Drawing.Size(640, 22);
            this.ssData.SizingGrip = false;
            this.ssData.TabIndex = 0;
            this.ssData.Text = "statusStrip1";
            // 
            // tsslRowsCount
            // 
            this.tsslRowsCount.Name = "tsslRowsCount";
            this.tsslRowsCount.Size = new System.Drawing.Size(156, 17);
            this.tsslRowsCount.Spring = true;
            // 
            // tsslRowsFiltered
            // 
            this.tsslRowsFiltered.Name = "tsslRowsFiltered";
            this.tsslRowsFiltered.Size = new System.Drawing.Size(156, 17);
            this.tsslRowsFiltered.Spring = true;
            // 
            // tsslSort
            // 
            this.tsslSort.Name = "tsslSort";
            this.tsslSort.Size = new System.Drawing.Size(156, 17);
            this.tsslSort.Spring = true;
            // 
            // tsslOffsetLimit
            // 
            this.tsslOffsetLimit.Name = "tsslOffsetLimit";
            this.tsslOffsetLimit.Size = new System.Drawing.Size(156, 17);
            this.tsslOffsetLimit.Spring = true;
            // 
            // lblFilterExpr
            // 
            this.lblFilterExpr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilterExpr.Location = new System.Drawing.Point(35, 4);
            this.lblFilterExpr.Name = "lblFilterExpr";
            this.lblFilterExpr.Size = new System.Drawing.Size(602, 26);
            this.lblFilterExpr.TabIndex = 0;
            this.lblFilterExpr.Text = "Filter expression";
            this.lblFilterExpr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panFilters
            // 
            this.panFilters.Controls.Add(this.btnResetFilters);
            this.panFilters.Controls.Add(this.lblFilterExpr);
            this.panFilters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panFilters.Location = new System.Drawing.Point(0, 425);
            this.panFilters.Name = "panFilters";
            this.panFilters.Size = new System.Drawing.Size(640, 33);
            this.panFilters.TabIndex = 2;
            this.panFilters.Visible = false;
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetFilters.Image = global::PgEdit.Properties.Resources.Clearallrequests_8816;
            this.btnResetFilters.Location = new System.Drawing.Point(3, 4);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(26, 26);
            this.btnResetFilters.TabIndex = 1;
            this.toolTip.SetToolTip(this.btnResetFilters, "Сбросить фильтр");
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // tsData
            // 
            this.tsData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh});
            this.tsData.Location = new System.Drawing.Point(0, 0);
            this.tsData.Name = "tsData";
            this.tsData.Size = new System.Drawing.Size(640, 25);
            this.tsData.TabIndex = 0;
            this.tsData.Text = "toolStrip1";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Enabled = false;
            this.tsbRefresh.Image = global::PgEdit.Properties.Resources.refresh_16xLG;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbRefresh.Text = "Обновить F5";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // DataWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.tsData);
            this.Controls.Add(this.panFilters);
            this.Controls.Add(this.ssData);
            this.Name = "DataWorkspace";
            this.Size = new System.Drawing.Size(640, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.cmsData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsData)).EndInit();
            this.ssData.ResumeLayout(false);
            this.ssData.PerformLayout();
            this.panFilters.ResumeLayout(false);
            this.tsData.ResumeLayout(false);
            this.tsData.PerformLayout();
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
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Label lblFilterExpr;
        private System.Windows.Forms.Panel panFilters;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStrip tsData;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ContextMenuStrip cmsData;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.ToolStripStatusLabel tsslSort;
    }
}
