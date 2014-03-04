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
    public partial class frmMain : Form
    {
        private Universe universe;

        public frmMain()
        {
            InitializeComponent();
        }

        private void OpenDatabase(TreeNode node) {
            Database db = (Database) node.Tag;
            using (NpgsqlConnection connection = TreeService.GetConnection(node))
            {
                connection.Open();
                db.Schemas = DatabaseService.fetchDatabaseSchema(connection);
            }

            List<TreeNode> subNodes = TreeService.ConvertDBSchemaToTreeNodes(db);

            tvStructure.SuspendLayout();
            node.Nodes.Clear();
            node.Nodes.AddRange(subNodes.ToArray());
            node.ExpandAll();
            tvStructure.ResumeLayout();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            universe = ConnectionService.Load();

            List<TreeNode> rootNodes = TreeService.ConvertSettingsToTreeNodes(universe);

            tvStructure.Nodes.AddRange(rootNodes.ToArray());
            tvStructure.ExpandAll();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tvStructure_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Node.Tag is Database)
                {
                    OpenDatabase(e.Node);
                }
                else if (e.Node.Tag is DataTable)
                {
                    DataTable table = (DataTable)e.Node.Tag;
                    using (NpgsqlConnection connection = TreeService.GetConnection(e.Node))
                    {
                        connection.Open();
                        DatabaseService.fetchTableByName(connection, table);
                    }
                    dgvData.DataMember = table.TableName;
                    dgvData.DataSource = table.DataSet;
                }
            }
        }

        private void tvStructure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) &&
                tvStructure.SelectedNode != null &&
                tvStructure.SelectedNode.Tag is Database)
            {
                OpenDatabase(tvStructure.SelectedNode);
                e.Handled = true;
            }
        }

    }
}
