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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrimaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colForeignKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNotNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUnique = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColumns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colType,
            this.colPrimaryKey,
            this.colForeignKey,
            this.colNotNull,
            this.colUnique,
            this.colDefaultValue,
            this.colDescription});
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.Location = new System.Drawing.Point(0, 0);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.ReadOnly = true;
            this.dgvColumns.RowHeadersVisible = false;
            this.dgvColumns.Size = new System.Drawing.Size(640, 480);
            this.dgvColumns.StandardTab = true;
            this.dgvColumns.TabIndex = 1;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "Name";
            this.colName.Frozen = true;
            this.colName.HeaderText = "Имя";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 54;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colType.DataPropertyName = "PgType";
            this.colType.HeaderText = "Тип";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 51;
            // 
            // colPrimaryKey
            // 
            this.colPrimaryKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colPrimaryKey.DataPropertyName = "PrimaryKey";
            this.colPrimaryKey.HeaderText = "Первичный ключ";
            this.colPrimaryKey.Name = "colPrimaryKey";
            this.colPrimaryKey.ReadOnly = true;
            this.colPrimaryKey.Width = 88;
            // 
            // colForeignKey
            // 
            this.colForeignKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colForeignKey.DataPropertyName = "ForeignKey";
            this.colForeignKey.HeaderText = "Внешний ключ";
            this.colForeignKey.Name = "colForeignKey";
            this.colForeignKey.ReadOnly = true;
            this.colForeignKey.Width = 77;
            // 
            // colNotNull
            // 
            this.colNotNull.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNotNull.DataPropertyName = "NotNull";
            this.colNotNull.HeaderText = "Не Null";
            this.colNotNull.Name = "colNotNull";
            this.colNotNull.ReadOnly = true;
            this.colNotNull.Width = 43;
            // 
            // colUnique
            // 
            this.colUnique.DataPropertyName = "Unique";
            this.colUnique.HeaderText = "Уникальный";
            this.colUnique.Name = "colUnique";
            this.colUnique.ReadOnly = true;
            // 
            // colDefaultValue
            // 
            this.colDefaultValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDefaultValue.DataPropertyName = "DefaultValue";
            this.colDefaultValue.HeaderText = "По умолчанию";
            this.colDefaultValue.Name = "colDefaultValue";
            this.colDefaultValue.ReadOnly = true;
            this.colDefaultValue.Width = 96;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Описание";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // TableWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvColumns);
            this.Name = "TableWorkspace";
            this.Size = new System.Drawing.Size(640, 480);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPrimaryKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colForeignKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colNotNull;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUnique;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}
