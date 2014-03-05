﻿namespace PgEdit
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tvStructure = new System.Windows.Forms.TreeView();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.msMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvStructure
            // 
            this.tvStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStructure.Location = new System.Drawing.Point(0, 0);
            this.tvStructure.Name = "tvStructure";
            this.tvStructure.Size = new System.Drawing.Size(200, 537);
            this.tvStructure.TabIndex = 0;
            this.tvStructure.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvStructure_AfterSelect);
            this.tvStructure.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvStructure_NodeMouseDoubleClick);
            this.tvStructure.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tvStructure_KeyPress);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(580, 537);
            this.dgvData.TabIndex = 1;
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDB});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(784, 24);
            this.msMainMenu.TabIndex = 2;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // tsmiDB
            // 
            this.tsmiDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRegister,
            this.tsmiConnect,
            this.tsmiDisconnect,
            this.tsmiExit});
            this.tsmiDB.Name = "tsmiDB";
            this.tsmiDB.Size = new System.Drawing.Size(86, 20);
            this.tsmiDB.Text = "База данных";
            // 
            // tsmiRegister
            // 
            this.tsmiRegister.Name = "tsmiRegister";
            this.tsmiRegister.Size = new System.Drawing.Size(231, 22);
            this.tsmiRegister.Text = "Зарегистрировать";
            // 
            // tsmiConnect
            // 
            this.tsmiConnect.Name = "tsmiConnect";
            this.tsmiConnect.Size = new System.Drawing.Size(231, 22);
            this.tsmiConnect.Text = "Подключиться к выбранной";
            this.tsmiConnect.Click += new System.EventHandler(this.tsmiConnect_Click);
            // 
            // tsmiDisconnect
            // 
            this.tsmiDisconnect.Name = "tsmiDisconnect";
            this.tsmiDisconnect.Size = new System.Drawing.Size(231, 22);
            this.tsmiDisconnect.Text = "Отключиться от выбранной";
            this.tsmiDisconnect.Click += new System.EventHandler(this.tsmiDisconnect_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(231, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 24);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tvStructure);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.dgvData);
            this.scMain.Size = new System.Drawing.Size(784, 537);
            this.scMain.SplitterDistance = 200;
            this.scMain.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "frmMain";
            this.Text = "PgEdit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvStructure;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiDB;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegister;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisconnect;
    }
}