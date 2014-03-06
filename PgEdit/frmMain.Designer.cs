namespace PgEdit
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tvStructure = new System.Windows.Forms.TreeView();
            this.ilTreeView = new System.Windows.Forms.ImageList(this.components);
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRegisteredDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tabTable = new System.Windows.Forms.TabControl();
            this.tpColumns = new System.Windows.Forms.TabPage();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrimaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colForeignKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUnique = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNotNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpData = new System.Windows.Forms.TabPage();
            this.tsmiBugReport = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.msMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tpColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.tpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvStructure
            // 
            this.tvStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStructure.ImageIndex = 0;
            this.tvStructure.ImageList = this.ilTreeView;
            this.tvStructure.Location = new System.Drawing.Point(0, 0);
            this.tvStructure.Name = "tvStructure";
            this.tvStructure.SelectedImageIndex = 0;
            this.tvStructure.Size = new System.Drawing.Size(200, 537);
            this.tvStructure.TabIndex = 0;
            this.tvStructure.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvStructure_AfterSelect);
            this.tvStructure.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvStructure_NodeMouseDoubleClick);
            this.tvStructure.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tvStructure_KeyPress);
            // 
            // ilTreeView
            // 
            this.ilTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilTreeView.ImageSize = new System.Drawing.Size(16, 16);
            this.ilTreeView.TransparentColor = System.Drawing.Color.Transparent;
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
            this.dgvData.Location = new System.Drawing.Point(3, 3);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(566, 505);
            this.dgvData.TabIndex = 1;
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDB,
            this.tsmiHelp});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(784, 24);
            this.msMainMenu.TabIndex = 2;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // tsmiDB
            // 
            this.tsmiDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConnect,
            this.tsmiDisconnect,
            this.tsSeparator1,
            this.tsmiRegisteredDB,
            this.tsmiExit});
            this.tsmiDB.Name = "tsmiDB";
            this.tsmiDB.Size = new System.Drawing.Size(86, 20);
            this.tsmiDB.Text = "База данных";
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
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            this.tsSeparator1.Size = new System.Drawing.Size(228, 6);
            // 
            // tsmiRegisteredDB
            // 
            this.tsmiRegisteredDB.Name = "tsmiRegisteredDB";
            this.tsmiRegisteredDB.Size = new System.Drawing.Size(231, 22);
            this.tsmiRegisteredDB.Text = "Зарегистрированные...";
            this.tsmiRegisteredDB.Click += new System.EventHandler(this.tsmiRegisteredDB_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(231, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBugReport,
            this.tsmiAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(68, 20);
            this.tsmiHelp.Text = "Помощь";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(231, 22);
            this.tsmiAbout.Text = "О программе...";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
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
            this.scMain.Panel2.Controls.Add(this.tabTable);
            this.scMain.Size = new System.Drawing.Size(784, 537);
            this.scMain.SplitterDistance = 200;
            this.scMain.TabIndex = 3;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.tpColumns);
            this.tabTable.Controls.Add(this.tpData);
            this.tabTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTable.Location = new System.Drawing.Point(0, 0);
            this.tabTable.Name = "tabTable";
            this.tabTable.SelectedIndex = 0;
            this.tabTable.Size = new System.Drawing.Size(580, 537);
            this.tabTable.TabIndex = 2;
            // 
            // tpColumns
            // 
            this.tpColumns.Controls.Add(this.dgvColumns);
            this.tpColumns.Location = new System.Drawing.Point(4, 22);
            this.tpColumns.Name = "tpColumns";
            this.tpColumns.Padding = new System.Windows.Forms.Padding(3);
            this.tpColumns.Size = new System.Drawing.Size(572, 511);
            this.tpColumns.TabIndex = 0;
            this.tpColumns.Text = "Поля";
            this.tpColumns.UseVisualStyleBackColor = true;
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colType,
            this.colPrimaryKey,
            this.colForeignKey,
            this.colUnique,
            this.colNotNull,
            this.colDefaultValue,
            this.colDescription});
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.Location = new System.Drawing.Point(3, 3);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.ReadOnly = true;
            this.dgvColumns.RowHeadersVisible = false;
            this.dgvColumns.Size = new System.Drawing.Size(566, 505);
            this.dgvColumns.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "name";
            this.colName.Frozen = true;
            this.colName.HeaderText = "Имя";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 54;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colType.DataPropertyName = "type";
            this.colType.HeaderText = "Тип";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 51;
            // 
            // colPrimaryKey
            // 
            this.colPrimaryKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colPrimaryKey.DataPropertyName = "primarykey";
            this.colPrimaryKey.HeaderText = "Первичный ключ";
            this.colPrimaryKey.Name = "colPrimaryKey";
            this.colPrimaryKey.ReadOnly = true;
            this.colPrimaryKey.Width = 88;
            // 
            // colForeignKey
            // 
            this.colForeignKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colForeignKey.DataPropertyName = "foreignkey";
            this.colForeignKey.HeaderText = "Внешний ключ";
            this.colForeignKey.Name = "colForeignKey";
            this.colForeignKey.ReadOnly = true;
            this.colForeignKey.Width = 77;
            // 
            // colUnique
            // 
            this.colUnique.DataPropertyName = "uniquekey";
            this.colUnique.HeaderText = "Уникальный";
            this.colUnique.Name = "colUnique";
            this.colUnique.ReadOnly = true;
            // 
            // colNotNull
            // 
            this.colNotNull.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNotNull.DataPropertyName = "notnull";
            this.colNotNull.HeaderText = "Не Null";
            this.colNotNull.Name = "colNotNull";
            this.colNotNull.ReadOnly = true;
            this.colNotNull.Width = 43;
            // 
            // colDefaultValue
            // 
            this.colDefaultValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDefaultValue.DataPropertyName = "default";
            this.colDefaultValue.HeaderText = "По умолчанию";
            this.colDefaultValue.Name = "colDefaultValue";
            this.colDefaultValue.ReadOnly = true;
            this.colDefaultValue.Width = 96;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "description";
            this.colDescription.HeaderText = "Описание";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.dgvData);
            this.tpData.Location = new System.Drawing.Point(4, 22);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(572, 511);
            this.tpData.TabIndex = 1;
            this.tpData.Text = "Данные";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // tsmiBugReport
            // 
            this.tsmiBugReport.Name = "tsmiBugReport";
            this.tsmiBugReport.Size = new System.Drawing.Size(231, 22);
            this.tsmiBugReport.Text = "Feature Request/Bug Report...";
            this.tsmiBugReport.Click += new System.EventHandler(this.tsmiBugReport_Click);
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
            this.tabTable.ResumeLayout(false);
            this.tpColumns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.tpData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvStructure;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiDB;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisconnect;
        private System.Windows.Forms.TabControl tabTable;
        private System.Windows.Forms.TabPage tpColumns;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.TabPage tpData;
        private System.Windows.Forms.ImageList ilTreeView;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPrimaryKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colForeignKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUnique;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colNotNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegisteredDB;
        private System.Windows.Forms.ToolStripMenuItem tsmiBugReport;
    }
}