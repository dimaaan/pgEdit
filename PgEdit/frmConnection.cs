using PgEdit.Domain;
using PgEdit.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgEdit
{
    /// <summary>
    /// Creates or views database connections
    /// </summary>
    /// <remarks>
    /// Bird eye view:
    /// This form used in 2 scenarios: creating new connection settings and viewing existing connection settings (see constructors for more info).
    /// 
    /// In 'create new connection' mode frmConnection_Load method creates new server, database and sshTunnel domain objects and binds it to controls.
    /// Changing contols by user changes domain object's properties.
    /// When user click OK validation function check settings and if its OK then dialog closes with 'DialogResult.OK'.
    /// Then newly created domain objects can be obtained via public propery 'Server'.
    /// 
    /// In 'view connection' mode corresponded domain object passed to form via constructor and binds to controls just as it in 'create new connection' mode.
    /// All editing controls disables exept check connection buttons.
    /// So use can't change anything.
    /// It this scenario 'DialogResult.OK' and frmConnection.Server property should be ignored
    /// </remarks>
    public partial class frmConnection : Form
    {
        // Test connection colors
        private readonly Color COLOR_SUCCESS = Color.Green;
        private readonly Color COLOR_FAIL = Color.Red;
        private readonly Color COLOR_UNKNOWN = Color.Gray;

        private Server server;
        private Database database;
        private SshTunnel sshTunnel;

        private Universe universe;

        private bool viewMode;

        /// <summary>
        /// For Windows Forms Designer only. 
        /// Use ctor with parameters.
        /// </summary>
        public frmConnection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates dialog for new connection
        /// </summary>
        public frmConnection(Universe universe) 
            : this()
        {
            this.universe = universe;
        }

        /// <summary>
        /// Creates dialog for viewing existing connection
        /// </summary>
        public frmConnection(Universe universe, Server server, Database database) 
            : this(universe)
        {
            this.server = server;
            this.database = database;
            this.sshTunnel = server.Ssh;
            viewMode = true;
        }

        public Server Server
        {
            get
            {
                return server;
            }
        }

        /// <summary>
        /// Returns name of class property using expression trees
        /// </summary>
        public static string PropertyName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }

        private void ResetConnectionStatuses()
        {
            ctrlConnectionStatus.BackColor = COLOR_UNKNOWN;
            ctrlSshConnectionStatus.BackColor = COLOR_UNKNOWN;
        }

        private void FillDatabaseList()
        {
            using (var connection = ConnectionService.GetConnection(server, database))
            {
                connection.Open();
                cmbDatabase.DataSource = DatabaseService.fetchDbNames(connection);
                ctrlConnectionStatus.BackColor = COLOR_SUCCESS;
            }
        }

        private bool ValidateControl(Control c)
        {
            CancelEventArgs cea = new CancelEventArgs();

            ctrl_Validating(c, cea);

            if (!cea.Cancel)
            {
                ctrl_Validated(c, EventArgs.Empty);
            }

            return !cea.Cancel;
        }

        private bool ValidateSshSettings()
        {
            bool a = ValidateControl(cmbSshHost);
            bool b = ValidateControl(txtSshUser);
            bool c;

            if (chkSshKey.Checked)
            {
                c = ValidateControl(txtSshKey);
            }
            else 
            {
                ctrl_Validated(txtSshKey, EventArgs.Empty);
                c = true;
            }

            return a && b && c;
        }

        private void frmConnection_Load(object sender, EventArgs e)
        {
            ResetConnectionStatuses();

            if (viewMode)
            {
                if (sshTunnel == null)
                {
                    sshTunnel = new SshTunnel();
                }

                cmbHost.Enabled =
                    nudPort.Enabled =
                    txtUser.Enabled =
                    txtPassword.Enabled =
                    chkShowDBPass.Enabled =
                    cmbDatabase.Enabled =
                    chkUseSsh.Enabled =
                    cmbSshHost.Enabled =
                    nudSshPort.Enabled =
                    txtSshUser.Enabled =
                    txtSshPassword.Enabled =
                    chkShowSshPass.Enabled =
                    chkSshKey.Enabled =
                    txtSshKey.Enabled =
                    btnShhKey.Enabled = false;
                chkUseSsh.Checked = server.Ssh != null;
            }
            else
            {
                database = new Database();
                server = new Server();
                sshTunnel = new SshTunnel();

                server.Databases.Add(database);
            }

            // autocomplite for ComboBoxes
            foreach(var s in universe.Servers)
                cmbHost.Items.Add(s.Address);

            foreach (var s in universe.Servers)
                if (s.Ssh != null)
                    cmbSshHost.Items.Add(s.Ssh.Server);


            // bind controls to domain objects
            Binding b;
            List<Binding> bindings = new List<Binding>();

            b = cmbHost.DataBindings.Add(
                PropertyName((ComboBox c) => c.Text), 
                server, 
                PropertyName((Server c) => c.Address), 
                false, DataSourceUpdateMode.OnValidation);
            bindings.Add(b);

            b = nudPort.DataBindings.Add(
                PropertyName((NumericUpDown c) => c.Value),
                server,
                PropertyName((Server c) => c.Port),
                false, DataSourceUpdateMode.OnValidation);
            bindings.Add(b);

            b = txtUser.DataBindings.Add(
                PropertyName((TextBox c) => c.Text),
                database,
                PropertyName((Database c) => c.User),
                false, DataSourceUpdateMode.OnValidation);
            bindings.Add(b);

            b = txtPassword.DataBindings.Add(
                PropertyName((TextBox c) => c.Text),
                database,
                PropertyName((Database c) => c.Password),
                false, DataSourceUpdateMode.OnValidation);
            bindings.Add(b);

            b = cmbDatabase.DataBindings.Add(
                PropertyName((ComboBox c) => c.Text),
                database,
                PropertyName((Database c) => c.Name),
                false, DataSourceUpdateMode.OnValidation);
            bindings.Add(b);

            b = cmbSshHost.DataBindings.Add(
                PropertyName((ComboBox c) => c.Text),
                sshTunnel,
                PropertyName((SshTunnel c) => c.Server),
                false, DataSourceUpdateMode.OnValidation);
            bindings.Add(b);

            b = nudSshPort.DataBindings.Add(
                PropertyName((NumericUpDown c) => c.Value),
                sshTunnel,
                PropertyName((SshTunnel c) => c.Port),
                false, DataSourceUpdateMode.OnValidation);
            bindings.Add(b);

            b = txtSshUser.DataBindings.Add(
                PropertyName((TextBox c) => c.Text),
                sshTunnel,
                PropertyName((SshTunnel c) => c.User),
                false, DataSourceUpdateMode.OnValidation);
            bindings.Add(b);

            b = txtSshPassword.DataBindings.Add(
                PropertyName((TextBox c) => c.Text),
                sshTunnel,
                PropertyName((SshTunnel c) => c.Password),
                false, DataSourceUpdateMode.OnValidation);
            bindings.Add(b);

            b = txtSshKey.DataBindings.Add(
                PropertyName((TextBox c) => c.Text),
                sshTunnel,
                PropertyName((SshTunnel c) => c.KeyFilePath),
                false, DataSourceUpdateMode.OnValidation);
            bindings.Add(b);

            foreach(Binding binding in bindings) 
                binding.Format += binding_Parse;
        }

        private void binding_Parse(object sender, ConvertEventArgs e)
        {
            ResetConnectionStatuses();
        }

        private void btnTestSshConnection_Click(object sender, EventArgs e)
        {
            if (ValidateSshSettings())
            {
                try
                {
                    ConnectionService.CreateSSHTunnel(server);
                    ConnectionService.CloseSshTunnel(server);
                    ctrlSshConnectionStatus.BackColor = COLOR_SUCCESS;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctrlSshConnectionStatus.BackColor = COLOR_FAIL;
                }
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if(ValidateChildren(ValidationConstraints.Enabled)) 
            {
                try
                {
                    using (var connection = ConnectionService.GetConnection(server, database))
                    {
                        connection.Open();
                        ctrlConnectionStatus.BackColor = COLOR_SUCCESS;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctrlConnectionStatus.BackColor = COLOR_FAIL;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void cmbDatabase_DropDown(object sender, EventArgs e)
        {
            if (cmbDatabase.DataSource == null)
            {
                try
                {
                    FillDatabaseList();
                }
                catch
                {
                    ResetConnectionStatuses();
                }
            }
        }

        private void chkUseSsh_CheckedChanged(object sender, EventArgs e)
        {
            server.Ssh = chkUseSsh.Checked ? sshTunnel : null;
            panSsh.Enabled = chkUseSsh.Checked;
            ctrl_Validated(cmbSshHost, EventArgs.Empty);
            ctrl_Validated(txtSshUser, EventArgs.Empty);
            ctrl_Validated(txtSshKey, EventArgs.Empty);
            ResetConnectionStatuses();
        }

        private void chkShowDBPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowDBPass.Checked;
        }

        private void chkShowSshPass_CheckedChanged(object sender, EventArgs e)
        {
            txtSshPassword.UseSystemPasswordChar = !chkShowSshPass.Checked;
        }

        private void btnShhKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtSshKey.Text = dlg.FileName;
            }
        }

        private void chkSshKey_CheckedChanged(object sender, EventArgs e)
        {
            txtSshKey.Enabled = btnShhKey.Enabled = chkSshKey.Checked;
            sshTunnel.KeyFilePath = chkSshKey.Checked ? txtSshKey.Text : null;
        }

        private void ctrl_Validating(object sender, CancelEventArgs e)
        {
            Control c = (Control)sender;

            if (String.IsNullOrWhiteSpace(c.Text))
            {
                errorProvider.SetError(c, "Заполните это поле");
                e.Cancel = true;
            }
        }

        private void ctrl_Validated(object sender, EventArgs e)
        {
            Control c = (Control)sender;

            errorProvider.SetError(c, String.Empty);
        }
    }
}
