using System.Data;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRegisteredDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBugReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.ucTree = new PgEdit.TreeWorkspace();
            this.tabTable = new System.Windows.Forms.TabControl();
            this.tpColumns = new System.Windows.Forms.TabPage();
            this.tpData = new System.Windows.Forms.TabPage();
            this.ucTable = new PgEdit.DataWorkspace();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucColumns = new PgEdit.TableWorkspace();
            this.msMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tpColumns.SuspendLayout();
            this.tpData.SuspendLayout();
            this.SuspendLayout();
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
            this.tsmiNewConnection,
            this.tsmiConnect,
            this.tsmiDisconnect,
            this.tsSeparator1,
            this.tsmiRegisteredDB,
            this.tsmiExit});
            this.tsmiDB.Name = "tsmiDB";
            this.tsmiDB.Size = new System.Drawing.Size(86, 20);
            this.tsmiDB.Text = "База данных";
            // 
            // tsmiNewConnection
            // 
            this.tsmiNewConnection.Name = "tsmiNewConnection";
            this.tsmiNewConnection.Size = new System.Drawing.Size(231, 22);
            this.tsmiNewConnection.Text = "Новое подключение...";
            this.tsmiNewConnection.Click += new System.EventHandler(this.tsmiNewConnection_Click);
            // 
            // tsmiConnect
            // 
            this.tsmiConnect.Enabled = false;
            this.tsmiConnect.Name = "tsmiConnect";
            this.tsmiConnect.Size = new System.Drawing.Size(231, 22);
            this.tsmiConnect.Text = "Подключиться к выбранной";
            this.tsmiConnect.Click += new System.EventHandler(this.tsmiConnect_Click);
            // 
            // tsmiDisconnect
            // 
            this.tsmiDisconnect.Enabled = false;
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
            // tsmiBugReport
            // 
            this.tsmiBugReport.Name = "tsmiBugReport";
            this.tsmiBugReport.Size = new System.Drawing.Size(231, 22);
            this.tsmiBugReport.Text = "Feature Request/Bug Report...";
            this.tsmiBugReport.Click += new System.EventHandler(this.tsmiBugReport_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
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
            this.scMain.Panel1.Controls.Add(this.ucTree);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.tabTable);
            this.scMain.Size = new System.Drawing.Size(784, 537);
            this.scMain.SplitterDistance = 200;
            this.scMain.TabIndex = 3;
            // 
            // ucTree
            // 
            this.ucTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTree.Location = new System.Drawing.Point(0, 0);
            this.ucTree.Name = "ucTree";
            this.ucTree.Size = new System.Drawing.Size(200, 537);
            this.ucTree.TabIndex = 1;
            this.ucTree.Universe = null;
            this.ucTree.DatabaseOpened += new System.Action(this.ucTree_DatabaseOpened);
            this.ucTree.DatabaseClosed += new System.Action(this.ucTree_DatabaseClosed);
            this.ucTree.TableOpened += new System.Action<System.Data.DataTable>(this.ucTree_TableOpened);
            this.ucTree.SelectionChanged += new System.Action(this.ucTree_SelectionChanged);
            this.ucTree.NewConnection += new System.Action(this.ucTree_NewConnection);
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
            this.tpColumns.Controls.Add(this.ucColumns);
            this.tpColumns.Location = new System.Drawing.Point(4, 22);
            this.tpColumns.Name = "tpColumns";
            this.tpColumns.Padding = new System.Windows.Forms.Padding(3);
            this.tpColumns.Size = new System.Drawing.Size(572, 511);
            this.tpColumns.TabIndex = 0;
            this.tpColumns.Text = "Поля";
            this.tpColumns.UseVisualStyleBackColor = true;
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.ucTable);
            this.tpData.Location = new System.Drawing.Point(4, 22);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(572, 511);
            this.tpData.TabIndex = 1;
            this.tpData.Text = "Данные";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // ucTable
            // 
            this.ucTable.DataSource = null;
            this.ucTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTable.Location = new System.Drawing.Point(3, 3);
            this.ucTable.Name = "ucTable";
            this.ucTable.Size = new System.Drawing.Size(566, 505);
            this.ucTable.TabIndex = 0;
            this.ucTable.DataSourceNeedRefresh += new System.Action(this.ucTable_DataSourceNeedRefresh);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PgType";
            this.dataGridViewTextBoxColumn2.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "PrimaryKey";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Первичный ключ";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "ForeignKey";
            this.dataGridViewCheckBoxColumn2.HeaderText = "Внешний ключ";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "NotNull";
            this.dataGridViewCheckBoxColumn3.HeaderText = "Не Null";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.DataPropertyName = "Unique";
            this.dataGridViewCheckBoxColumn4.HeaderText = "Уникальный";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DefaultValue";
            this.dataGridViewTextBoxColumn3.HeaderText = "По умолчанию";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn4.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // ucColumns
            // 
            this.ucColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucColumns.Location = new System.Drawing.Point(3, 3);
            this.ucColumns.Name = "ucColumns";
            this.ucColumns.Size = new System.Drawing.Size(566, 505);
            this.ucColumns.TabIndex = 0;
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tpColumns.ResumeLayout(false);
            this.tpData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiDB;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisconnect;
        private System.Windows.Forms.TabControl tabTable;
        private System.Windows.Forms.TabPage tpColumns;
        private System.Windows.Forms.TabPage tpData;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegisteredDB;
        private System.Windows.Forms.ToolStripMenuItem tsmiBugReport;
        private DataWorkspace ucTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewConnection;
        private TreeWorkspace ucTree;
        private TableWorkspace ucColumns;
    }
}