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
    // TODO list of used hosts and ssh hosts
    // TODO same server different db problem (maybe merge tabs + add server aliases + when switch existing alias it adds to this server or different server & db dialogs)
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

        /// <summary>
        /// For Windows Forms Designer only. 
        /// Use ctor with parameters.
        /// </summary>
        public frmConnection()
        {
            InitializeComponent();
        }

        public frmConnection(Universe universe) 
            : this()
        {
            this.universe = universe;
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

            if (server == null)
            {
                sshTunnel = new SshTunnel();
                database = new Database();
                server = new Server();

                server.Databases.Add(database);
            }


            // autocomplite for ComboBoxes
            foreach(var s in universe.Servers) {
                cmbHost.Items.Add(s.Address);
            }

            foreach (var s in universe.Servers)
            {
                if (s.Ssh != null)
                {
                    cmbSshHost.Items.Add(s.Ssh.Server);
                }
            }


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

            b = txtShhPassword.DataBindings.Add(
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
            {
                binding.Format += binding_Parse;
            }
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
                    FillDatabaseList();
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
            ResetConnectionStatuses();
        }

        private void chkShowDBPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowDBPass.Checked;
        }

        private void chkShowSshPass_CheckedChanged(object sender, EventArgs e)
        {
            txtShhPassword.UseSystemPasswordChar = !chkShowSshPass.Checked;
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
