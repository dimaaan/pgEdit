using Npgsql;
using PgEdit.Domain;
using PgEdit.Properties;
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

        private const string IMAGE_KEY_SERVER = "server";
        private const string IMAGE_KEY_DATABASE_CONNECTED = "dbConnected";
        private const string IMAGE_KEY_DATABASE_DISCONNECTED = "dbDisconnected";
        private const string IMAGE_KEY_SCHEMA = "schema";
        private const string IMAGE_KEY_TABLE = "table";

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

            FillTreeViewWithTables(dbNode);

            
            dbNode.ImageKey = IMAGE_KEY_DATABASE_CONNECTED;
            dbNode.SelectedImageKey = IMAGE_KEY_DATABASE_CONNECTED;
            db.IsOpen = true;
            RefreshMenu();
        }

        private void CloseDatabase(TreeNode node)
        {
            TreeNode dbNode = GetSelectedDBNode(node);
            Database db = (Database)dbNode.Tag;

            dgvData.DataSource = null;
            dgvData.DataMember = null;
            db.Schemas = null;
            db.IsOpen = false;
            dbNode.Nodes.Clear();
            dbNode.ImageKey = IMAGE_KEY_DATABASE_DISCONNECTED;
            dbNode.SelectedImageKey = IMAGE_KEY_DATABASE_DISCONNECTED;
            RefreshMenu();
        }

        /// <summary>
        /// Return database node by it subnodes
        /// </summary>
        public static TreeNode GetSelectedDBNode(TreeNode node)
        {
            TreeNode res;

            if (node.Tag is Server)
            {
                res = null;
            }
            else if (node.Tag is DataTable || node.Tag is DataSet)
            {
                res = GetSelectedDBNode(node.Parent);
            }
            else if (node.Tag is Database)
            {
                res = node;
            }
            else
            {
                throw new InvalidOperationException("Invalid tree node type: " + node.Tag.GetType().ToString());
            }

            return res;
        }

        public void FillTreeViewOnStartup(Universe universe)
        {
            List<TreeNode> nodes = new List<TreeNode>();

            foreach (Server server in universe.Servers)
            {
                TreeNode nodeHost = new TreeNode()
                {
                    Text = server.Address,
                    Tag = server,
                    ImageKey = IMAGE_KEY_SERVER,
                    SelectedImageKey = IMAGE_KEY_SERVER
                };
                nodes.Add(nodeHost);

                foreach (Database db in server.Databases)
                {
                    TreeNode nodeDB = new TreeNode()
                    {
                        Text = db.Name,
                        Tag = db,
                        ImageKey = IMAGE_KEY_DATABASE_DISCONNECTED,
                        SelectedImageKey = IMAGE_KEY_DATABASE_DISCONNECTED
                    };
                    nodeHost.Nodes.Add(nodeDB);
                }
            }

            tvStructure.Nodes.AddRange(nodes.ToArray());
            tvStructure.ExpandAll();
        }

        private void ShowTable(TreeNode node)
        {
            DataTable table = (DataTable)node.Tag;
            TreeNode dbNode = GetSelectedDBNode(node);
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

        public static void FillTreeViewWithTables(TreeNode dbNode)
        {
            Database db = (Database)dbNode.Tag;
            List<TreeNode> nodes = new List<TreeNode>();

            foreach (DataSet schema in db.Schemas)
            {
                TreeNode schemaNode = new TreeNode()
                {
                    Text = schema.DataSetName,
                    Tag = schema,
                    ImageKey = IMAGE_KEY_SCHEMA,
                    SelectedImageKey = IMAGE_KEY_SCHEMA
                };
                nodes.Add(schemaNode);

                foreach (DataTable table in schema.Tables)
                {
                    TreeNode tableNode = new TreeNode()
                    {
                        Text = table.TableName,
                        Tag = table,
                        ImageKey = IMAGE_KEY_TABLE,
                        SelectedImageKey = IMAGE_KEY_TABLE
                    };

                    schemaNode.Nodes.Add(tableNode);
                }
            }

            dbNode.Nodes.AddRange(nodes.ToArray());
            dbNode.ExpandAll();
        }

        private void RefreshMenu()
        {
            TreeNode dbNode = GetSelectedDBNode(tvStructure.SelectedNode);

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
            Icon = Resources.logo;
            dgvColumns.AutoGenerateColumns = false;

            ilTreeView.Images.Add(IMAGE_KEY_SERVER, Resources.server_icon);
            ilTreeView.Images.Add(IMAGE_KEY_DATABASE_CONNECTED, Resources.Database_Active_icon);
            ilTreeView.Images.Add(IMAGE_KEY_DATABASE_DISCONNECTED, Resources.Database_Inactive_icon);
            ilTreeView.Images.Add(IMAGE_KEY_SCHEMA, Resources.tables_stacks_icon);
            ilTreeView.Images.Add(IMAGE_KEY_TABLE, Resources.table);

            universe = ConnectionService.Load();

            FillTreeViewOnStartup(universe);
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
