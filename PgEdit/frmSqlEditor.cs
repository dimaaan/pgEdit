using Npgsql;
using PgEdit.Domain;
using PgEdit.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgEdit
{
    public partial class frmSqlEditor : Form
    {
        private Server server;
        private Database database;

        /// <summary>
        /// For Windows Forms Designer only. 
        /// Use ctor with parameters.
        /// </summary>
        public frmSqlEditor()
        {
            InitializeComponent();
        }

        public frmSqlEditor(Server server, Database database)
            : this()
        {
            this.server = server;
            this.database = database;

            Text = String.Format("{0} - {1} на {2}", Text, database.Name, server.Address);
        }

        private void RunSql(string sql)
        {
            using (var connection = ConnectionService.GetConnection(server, database))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet queryResult = new DataSet();

                try
                {
                    adapter.Fill(queryResult);
                    if (queryResult.Tables.Count > 0)
                    {
                        dgvSqlResult.DataSource = queryResult.Tables[0];
                        tcResults.SelectedTab = tpSqlResult;
                    }
                }
                catch (NpgsqlException e)
                {
                    txtSqlError.Text = e.Message;
                    tcResults.SelectedTab = tpError;
                    txtSqlError.Select(0, 0);
                }
            }
        }

        private void tssbRun_ButtonClick(object sender, EventArgs e)
        {
            RunSql(txtSqlExpr.Text);
        }

        private void tssbRun_DropDownOpening(object sender, EventArgs e)
        {
            tsmiRunSelected.Enabled = !String.IsNullOrEmpty(txtSqlExpr.SelectedText);
        }

        private void tsmiRunSelected_Click(object sender, EventArgs e)
        {
            RunSql(txtSqlExpr.SelectedText);
        }

        /// <summary>
        /// Ctrl+A selects all text
        /// </summary>
        private void textBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (e.Control && (e.KeyCode == System.Windows.Forms.Keys.A))
            {
                txt.SelectAll();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void txtSqlExpr_TextChanged(object sender, EventArgs e)
        {
            tssbRun.Enabled = !String.IsNullOrWhiteSpace(txtSqlExpr.Text);
        }
    }
}
