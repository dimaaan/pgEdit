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

        private void OpenDatabase(TreeNode dbNode) {
            Database db = (Database)dbNode.Tag;
            Server server = (Server)dbNode.Parent.Tag;

            using (NpgsqlConnection connection = ConnectionService.GetConnection(server, db))
            {
                connection.Open();
                db.Schemas = DatabaseService.fetchAllSchemasWithTables(connection);
            }

            List<TreeNode> subNodes = TreeService.ConvertDBSchemaToTreeNodes(db);

            dbNode.Nodes.AddRange(subNodes.ToArray());
            dbNode.ExpandAll();
            db.IsOpen = true;
            RefreshMenu();
        }

        private void CloseDatabase(TreeNode node)
        {
            TreeNode dbNode = TreeService.GetSelectedDBNode(node);
            Database db = (Database)dbNode.Tag;

            dgvData.DataSource = null;
            dgvData.DataMember = null;
            db.Schemas = null;
            db.IsOpen = false;
            dbNode.Nodes.Clear();
            RefreshMenu();
        }

        private void RefreshMenu()
        {
            TreeNode dbNode = TreeService.GetSelectedDBNode(tvStructure.SelectedNode);

            tsmiConnect.Enabled = dbNode != null && !((Database)dbNode.Tag).IsOpen;
            tsmiDisconnect.Enabled = dbNode != null && ((Database)dbNode.Tag).IsOpen;
        }
        

        private void frmMain_Load(object sender, EventArgs e)
        {
            universe = ConnectionService.Load();

            List<TreeNode> rootNodes = TreeService.ConvertSettingsToTreeNodes(universe);

            tvStructure.Nodes.AddRange(rootNodes.ToArray());
            tvStructure.ExpandAll();
        }

        private void tsmiConnect_Click(object sender, EventArgs e)
        {
            OpenDatabase(tvStructure.SelectedNode);
        }

        private void tsmiDisconnect_Click(object sender, EventArgs e)
        {
            CloseDatabase(tvStructure.SelectedNode);
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
                    Database db = (Database)e.Node.Tag;

                    if (!db.IsOpen)
                    {
                        OpenDatabase(e.Node);
                    }
                }
                else if (e.Node.Tag is DataTable)
                {
                    DataTable table = (DataTable)e.Node.Tag;
                    TreeNode dbNode = TreeService.GetSelectedDBNode(e.Node);
                    Database db = (Database)dbNode.Tag;
                    Server server = (Server)dbNode.Parent.Tag;

                    using (NpgsqlConnection connection = ConnectionService.GetConnection(server, db))
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

        private void tvStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshMenu();            
        }

    }
}
