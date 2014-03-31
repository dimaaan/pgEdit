namespace PgEdit
{
    partial class frmConnection
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.cmbHost = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.panSsh = new System.Windows.Forms.Panel();
            this.btnShhKey = new System.Windows.Forms.Button();
            this.chkSshKey = new System.Windows.Forms.CheckBox();
            this.txtSshKey = new System.Windows.Forms.TextBox();
            this.chkShowSshPass = new System.Windows.Forms.CheckBox();
            this.ctrlSshConnectionStatus = new System.Windows.Forms.Control();
            this.btnTestSshConnection = new System.Windows.Forms.Button();
            this.lblSshHost = new System.Windows.Forms.Label();
            this.txtShhPassword = new System.Windows.Forms.TextBox();
            this.lblSshPort = new System.Windows.Forms.Label();
            this.txtSshUser = new System.Windows.Forms.TextBox();
            this.lblSshUser = new System.Windows.Forms.Label();
            this.nudSshPort = new System.Windows.Forms.NumericUpDown();
            this.lblShhPassword = new System.Windows.Forms.Label();
            this.cmbSshHost = new System.Windows.Forms.ComboBox();
            this.chkUseSsh = new System.Windows.Forms.CheckBox();
            this.ctrlConnectionStatus = new System.Windows.Forms.Control();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkShowDBPass = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.panSsh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSshPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(128, 62);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(213, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider.SetIconAlignment(this.txtUser, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtUser.Location = new System.Drawing.Point(128, 36);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(304, 20);
            this.txtUser.TabIndex = 5;
            this.txtUser.Validating += new System.ComponentModel.CancelEventHandler(this.ctrl_Validating);
            this.txtUser.Validated += new System.EventHandler(this.ctrl_Validated);
            // 
            // lblUser
            // 
            this.lblUser.AutoEllipsis = true;
            this.lblUser.Location = new System.Drawing.Point(12, 36);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(92, 20);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Пользователь:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoEllipsis = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 62);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(92, 20);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Пароль:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDatabase.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.cmbDatabase, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cmbDatabase.Location = new System.Drawing.Point(128, 88);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(304, 21);
            this.cmbDatabase.TabIndex = 10;
            this.cmbDatabase.DropDown += new System.EventHandler(this.cmbDatabase_DropDown);
            this.cmbDatabase.Validating += new System.ComponentModel.CancelEventHandler(this.ctrl_Validating);
            this.cmbDatabase.Validated += new System.EventHandler(this.ctrl_Validated);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Location = new System.Drawing.Point(12, 88);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(92, 21);
            this.lblDatabase.TabIndex = 9;
            this.lblDatabase.Text = "База данных:";
            this.lblDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudPort
            // 
            this.nudPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPort.Location = new System.Drawing.Point(347, 10);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(85, 20);
            this.nudPort.TabIndex = 3;
            // 
            // cmbHost
            // 
            this.cmbHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbHost.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.cmbHost, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cmbHost.Location = new System.Drawing.Point(128, 9);
            this.cmbHost.Name = "cmbHost";
            this.cmbHost.Size = new System.Drawing.Size(162, 21);
            this.cmbHost.TabIndex = 1;
            this.cmbHost.Validating += new System.ComponentModel.CancelEventHandler(this.ctrl_Validating);
            this.cmbHost.Validated += new System.EventHandler(this.ctrl_Validated);
            // 
            // lblPort
            // 
            this.lblPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPort.Location = new System.Drawing.Point(296, 10);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(45, 20);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Порт:";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHost
            // 
            this.lblHost.Location = new System.Drawing.Point(12, 9);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(92, 21);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Хост:";
            this.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panSsh
            // 
            this.panSsh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panSsh.Controls.Add(this.btnShhKey);
            this.panSsh.Controls.Add(this.chkSshKey);
            this.panSsh.Controls.Add(this.txtSshKey);
            this.panSsh.Controls.Add(this.chkShowSshPass);
            this.panSsh.Controls.Add(this.ctrlSshConnectionStatus);
            this.panSsh.Controls.Add(this.btnTestSshConnection);
            this.panSsh.Controls.Add(this.lblSshHost);
            this.panSsh.Controls.Add(this.txtShhPassword);
            this.panSsh.Controls.Add(this.lblSshPort);
            this.panSsh.Controls.Add(this.txtSshUser);
            this.panSsh.Controls.Add(this.lblSshUser);
            this.panSsh.Controls.Add(this.nudSshPort);
            this.panSsh.Controls.Add(this.lblShhPassword);
            this.panSsh.Controls.Add(this.cmbSshHost);
            this.panSsh.Enabled = false;
            this.panSsh.Location = new System.Drawing.Point(15, 138);
            this.panSsh.Name = "panSsh";
            this.panSsh.Size = new System.Drawing.Size(417, 164);
            this.panSsh.TabIndex = 12;
            // 
            // btnShhKey
            // 
            this.btnShhKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShhKey.Enabled = false;
            this.btnShhKey.Location = new System.Drawing.Point(382, 93);
            this.btnShhKey.Name = "btnShhKey";
            this.btnShhKey.Size = new System.Drawing.Size(32, 23);
            this.btnShhKey.TabIndex = 11;
            this.btnShhKey.Text = "...";
            this.btnShhKey.UseVisualStyleBackColor = true;
            this.btnShhKey.Click += new System.EventHandler(this.btnShhKey_Click);
            // 
            // chkSshKey
            // 
            this.chkSshKey.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSshKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSshKey.Location = new System.Drawing.Point(0, 94);
            this.chkSshKey.Name = "chkSshKey";
            this.chkSshKey.Size = new System.Drawing.Size(89, 20);
            this.chkSshKey.TabIndex = 9;
            this.chkSshKey.Text = "Ключ:";
            this.chkSshKey.UseVisualStyleBackColor = true;
            this.chkSshKey.CheckedChanged += new System.EventHandler(this.chkSshKey_CheckedChanged);
            // 
            // txtSshKey
            // 
            this.txtSshKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSshKey.Enabled = false;
            this.errorProvider.SetIconAlignment(this.txtSshKey, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtSshKey.Location = new System.Drawing.Point(113, 94);
            this.txtSshKey.Name = "txtSshKey";
            this.txtSshKey.Size = new System.Drawing.Size(263, 20);
            this.txtSshKey.TabIndex = 10;
            this.txtSshKey.Validating += new System.ComponentModel.CancelEventHandler(this.ctrl_Validating);
            this.txtSshKey.Validated += new System.EventHandler(this.ctrl_Validated);
            // 
            // chkShowSshPass
            // 
            this.chkShowSshPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowSshPass.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowSshPass.Location = new System.Drawing.Point(332, 68);
            this.chkShowSshPass.Name = "chkShowSshPass";
            this.chkShowSshPass.Size = new System.Drawing.Size(82, 20);
            this.chkShowSshPass.TabIndex = 8;
            this.chkShowSshPass.Text = "Показать";
            this.chkShowSshPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShowSshPass.UseVisualStyleBackColor = true;
            this.chkShowSshPass.CheckedChanged += new System.EventHandler(this.chkShowSshPass_CheckedChanged);
            // 
            // ctrlSshConnectionStatus
            // 
            this.ctrlSshConnectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlSshConnectionStatus.BackColor = System.Drawing.Color.Black;
            this.ctrlSshConnectionStatus.Location = new System.Drawing.Point(132, 129);
            this.ctrlSshConnectionStatus.Name = "ctrlSshConnectionStatus";
            this.ctrlSshConnectionStatus.Size = new System.Drawing.Size(23, 23);
            this.ctrlSshConnectionStatus.TabIndex = 12;
            this.ctrlSshConnectionStatus.TabStop = false;
            this.ctrlSshConnectionStatus.Text = "control1";
            // 
            // btnTestSshConnection
            // 
            this.btnTestSshConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestSshConnection.Location = new System.Drawing.Point(166, 129);
            this.btnTestSshConnection.Name = "btnTestSshConnection";
            this.btnTestSshConnection.Size = new System.Drawing.Size(251, 23);
            this.btnTestSshConnection.TabIndex = 13;
            this.btnTestSshConnection.Text = "Проверить подключение по SSH";
            this.btnTestSshConnection.UseVisualStyleBackColor = true;
            this.btnTestSshConnection.Click += new System.EventHandler(this.btnTestSshConnection_Click);
            // 
            // lblSshHost
            // 
            this.lblSshHost.AutoEllipsis = true;
            this.lblSshHost.Location = new System.Drawing.Point(-3, 12);
            this.lblSshHost.Name = "lblSshHost";
            this.lblSshHost.Size = new System.Drawing.Size(92, 21);
            this.lblSshHost.TabIndex = 0;
            this.lblSshHost.Text = "Хост:";
            this.lblSshHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtShhPassword
            // 
            this.txtShhPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShhPassword.Location = new System.Drawing.Point(113, 68);
            this.txtShhPassword.Name = "txtShhPassword";
            this.txtShhPassword.Size = new System.Drawing.Size(213, 20);
            this.txtShhPassword.TabIndex = 7;
            this.txtShhPassword.UseSystemPasswordChar = true;
            // 
            // lblSshPort
            // 
            this.lblSshPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSshPort.AutoEllipsis = true;
            this.lblSshPort.Location = new System.Drawing.Point(281, 15);
            this.lblSshPort.Name = "lblSshPort";
            this.lblSshPort.Size = new System.Drawing.Size(45, 20);
            this.lblSshPort.TabIndex = 2;
            this.lblSshPort.Text = "Порт:";
            this.lblSshPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSshUser
            // 
            this.txtSshUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider.SetIconAlignment(this.txtSshUser, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtSshUser.Location = new System.Drawing.Point(113, 42);
            this.txtSshUser.Name = "txtSshUser";
            this.txtSshUser.Size = new System.Drawing.Size(304, 20);
            this.txtSshUser.TabIndex = 5;
            this.txtSshUser.Validating += new System.ComponentModel.CancelEventHandler(this.ctrl_Validating);
            this.txtSshUser.Validated += new System.EventHandler(this.ctrl_Validated);
            // 
            // lblSshUser
            // 
            this.lblSshUser.AutoEllipsis = true;
            this.lblSshUser.Location = new System.Drawing.Point(-2, 42);
            this.lblSshUser.Name = "lblSshUser";
            this.lblSshUser.Size = new System.Drawing.Size(91, 20);
            this.lblSshUser.TabIndex = 4;
            this.lblSshUser.Text = "Пользователь:";
            this.lblSshUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudSshPort
            // 
            this.nudSshPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSshPort.Location = new System.Drawing.Point(332, 15);
            this.nudSshPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudSshPort.Name = "nudSshPort";
            this.nudSshPort.Size = new System.Drawing.Size(85, 20);
            this.nudSshPort.TabIndex = 3;
            // 
            // lblShhPassword
            // 
            this.lblShhPassword.AutoEllipsis = true;
            this.lblShhPassword.Location = new System.Drawing.Point(-3, 68);
            this.lblShhPassword.Name = "lblShhPassword";
            this.lblShhPassword.Size = new System.Drawing.Size(92, 20);
            this.lblShhPassword.TabIndex = 6;
            this.lblShhPassword.Text = "Пароль:";
            this.lblShhPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSshHost
            // 
            this.cmbSshHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSshHost.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.cmbSshHost, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cmbSshHost.Location = new System.Drawing.Point(113, 15);
            this.cmbSshHost.Name = "cmbSshHost";
            this.cmbSshHost.Size = new System.Drawing.Size(162, 21);
            this.cmbSshHost.TabIndex = 1;
            this.cmbSshHost.Validating += new System.ComponentModel.CancelEventHandler(this.ctrl_Validating);
            this.cmbSshHost.Validated += new System.EventHandler(this.ctrl_Validated);
            // 
            // chkUseSsh
            // 
            this.chkUseSsh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUseSsh.AutoEllipsis = true;
            this.chkUseSsh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUseSsh.Location = new System.Drawing.Point(15, 115);
            this.chkUseSsh.Name = "chkUseSsh";
            this.chkUseSsh.Size = new System.Drawing.Size(352, 24);
            this.chkUseSsh.TabIndex = 11;
            this.chkUseSsh.Text = "Подключение через SSH туннель";
            this.chkUseSsh.UseVisualStyleBackColor = true;
            this.chkUseSsh.CheckedChanged += new System.EventHandler(this.chkUseSsh_CheckedChanged);
            // 
            // ctrlConnectionStatus
            // 
            this.ctrlConnectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlConnectionStatus.BackColor = System.Drawing.Color.Black;
            this.ctrlConnectionStatus.Location = new System.Drawing.Point(12, 321);
            this.ctrlConnectionStatus.Name = "ctrlConnectionStatus";
            this.ctrlConnectionStatus.Size = new System.Drawing.Size(23, 23);
            this.ctrlConnectionStatus.TabIndex = 13;
            this.ctrlConnectionStatus.TabStop = false;
            this.ctrlConnectionStatus.Text = "control1";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestConnection.Location = new System.Drawing.Point(41, 321);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(166, 23);
            this.btnTestConnection.TabIndex = 14;
            this.btnTestConnection.Text = "Проверить подключение";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(276, 321);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(357, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkShowDBPass
            // 
            this.chkShowDBPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowDBPass.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowDBPass.Location = new System.Drawing.Point(347, 62);
            this.chkShowDBPass.Name = "chkShowDBPass";
            this.chkShowDBPass.Size = new System.Drawing.Size(85, 20);
            this.chkShowDBPass.TabIndex = 8;
            this.chkShowDBPass.Text = "Показать";
            this.chkShowDBPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShowDBPass.UseVisualStyleBackColor = true;
            this.chkShowDBPass.CheckedChanged += new System.EventHandler(this.chkShowDBPass_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // frmConnection
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(444, 356);
            this.Controls.Add(this.chkShowDBPass);
            this.Controls.Add(this.panSsh);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.chkUseSsh);
            this.Controls.Add(this.ctrlConnectionStatus);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbDatabase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.cmbHost);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(460, 395);
            this.Name = "frmConnection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Подключение к БД";
            this.Load += new System.EventHandler(this.frmConnection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.panSsh.ResumeLayout(false);
            this.panSsh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSshPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.ComboBox cmbHost;
        private System.Windows.Forms.CheckBox chkUseSsh;
        private System.Windows.Forms.Panel panSsh;
        private System.Windows.Forms.Label lblSshHost;
        private System.Windows.Forms.TextBox txtShhPassword;
        private System.Windows.Forms.Label lblSshPort;
        private System.Windows.Forms.TextBox txtSshUser;
        private System.Windows.Forms.Label lblSshUser;
        private System.Windows.Forms.NumericUpDown nudSshPort;
        private System.Windows.Forms.Label lblShhPassword;
        private System.Windows.Forms.ComboBox cmbSshHost;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Control ctrlSshConnectionStatus;
        private System.Windows.Forms.Button btnTestSshConnection;
        private System.Windows.Forms.Control ctrlConnectionStatus;
        private System.Windows.Forms.CheckBox chkShowSshPass;
        private System.Windows.Forms.CheckBox chkShowDBPass;
        private System.Windows.Forms.Button btnShhKey;
        private System.Windows.Forms.CheckBox chkSshKey;
        private System.Windows.Forms.TextBox txtSshKey;
        private System.Windows.Forms.ErrorProvider errorProvider;

    }
}