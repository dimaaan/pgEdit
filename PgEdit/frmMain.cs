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
                foreach (DataSet schema in db.Schemas)
                {
                    db.Columns[schema.DataSetName] = new Dictionary<string, DataTable>();
                }
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

        private void ShowTable(TreeNode node)
        {
            DataTable table = (DataTable)node.Tag;
            TreeNode dbNode = TreeService.GetSelectedDBNode(node);
            Database db = (Database)dbNode.Tag;
            Server server = (Server)dbNode.Parent.Tag;
            DataTable tableColumns;

            using (NpgsqlConnection connection = ConnectionService.GetConnection(server, db))
            {
                connection.Open();
                DatabaseService.fetchTableByName(connection, table);
                tableColumns = DatabaseService.fetchTableColumns(connection, table.DataSet.DataSetName, table.TableName);
                db.Columns[table.DataSet.DataSetName][table.TableName] = tableColumns;
            }

            dgvColumns.DataSource = tableColumns;
            dgvData.DataMember = table.TableName;
            dgvData.DataSource = table.DataSet;
        }

        private void RefreshMenu()
        {
            TreeNode dbNode = TreeService.GetSelectedDBNode(tvStructure.SelectedNode);

            tsmiConnect.Enabled = dbNode != null && !((Database)dbNode.Tag).IsOpen;
            tsmiDisconnect.Enabled = dbNode != null && ((Database)dbNode.Tag).IsOpen;
        }

        private void SelectTreeNode(TreeNode node)
        {
            if (node.Tag != null)
            {
                if (node.Tag is Database)
                {
                    Database db = (Database)node.Tag;

                    if (!db.IsOpen)
                    {
                        OpenDatabase(node);
                    }
                }
                else if (node.Tag is DataTable)
                {
                    ShowTable(node);
                }
            }
        }
        

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvColumns.AutoGenerateColumns = false;

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
            SelectTreeNode(e.Node);
        }

        private void tvStructure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) &&
                tvStructure.SelectedNode != null)
            {
                SelectTreeNode(tvStructure.SelectedNode);
                e.Handled = true;
            }
        }

        private void tvStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshMenu();            
        }

    }
}
