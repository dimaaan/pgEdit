using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PgEdit.Domain;
using PgEdit.Service;
using Npgsql;
using PgEdit.Properties;

namespace PgEdit
{
    /// <summary>
    /// To create TreeWorkspace set property Universe and call FillTreeView()
    /// </summary>
    public partial class TreeWorkspace : UserControl
    {
        private const string IMAGE_KEY_SERVER = "server";
        private const string IMAGE_KEY_DATABASE_CONNECTED = "dbConnected";
        private const string IMAGE_KEY_DATABASE_DISCONNECTED = "dbDisconnected";
        private const string IMAGE_KEY_SCHEMA = "schema";
        private const string IMAGE_KEY_TABLE = "table";
        private const string IMAGE_KEY_TABLE_OPEN = "table-open";

        private Universe universe;

        private TreeNode openedTableNode;

        public Universe Universe
        {
            get
            {
                return universe;
            }
            set
            {
                universe = value;
            }
        }

        public Database SelectedDatabase
        {
            get
            {
                Database res = null;
                TreeNode dbNode = GetSelectedDBNode(tvTree.SelectedNode);

                if (dbNode != null)
                {
                    res = (Database)dbNode.Tag;
                }

                return res;
            }
        }

        public TreeNode SelectedNode
        {
            get
            {
                return tvTree.SelectedNode;
            }
        }

        public TreeNode OpenedTableNode
        {
            get
            {
                return openedTableNode;
            }
        }

        public TreeWorkspace()
        {
            InitializeComponent();
        }

        public event Action DatabaseOpened;
        public event Action DatabaseClosed;
        public event Action<DataTable> TableOpened;
        public event Action SelectionChanged;
        public event Action NewConnection;

        public void FillTreeView()
        {
            tvTree.SuspendLayout();
            tvTree.Nodes.Clear();

            foreach (Server server in universe.Servers)
            {
                TreeNode nodeHost = ServerToNode(server);
                tvTree.Nodes.Add(nodeHost);
            }

            tvTree.ExpandAll();
            tvTree.ResumeLayout();
        }

        private void OpenDatabase(TreeNode dbNode)
        {
            Database db = (Database)dbNode.Tag;
            Server server = (Server)dbNode.Parent.Tag;

            using (NpgsqlConnection connection = ConnectionService.GetConnection(server, db))
            {
                connection.Open();
                db.Schemas = DatabaseService.fetchAllSchemasWithTables(connection);
            }

            FillTreeViewWithTables(dbNode);


            dbNode.ImageKey = IMAGE_KEY_DATABASE_CONNECTED;
            dbNode.SelectedImageKey = IMAGE_KEY_DATABASE_CONNECTED;
            db.IsOpen = true;

            if (DatabaseOpened != null)
                DatabaseOpened();
        }

        public void OpenSelectedDatabase()
        {
            OpenDatabase(tvTree.SelectedNode);
        }

        private void CloseDatabase(TreeNode dbNode)
        {
            Database db = (Database)dbNode.Tag;

            if (db.IsOpen)
            {
                db.Schemas = null;
                db.IsOpen = false;
                dbNode.Nodes.Clear();
                dbNode.ImageKey = IMAGE_KEY_DATABASE_DISCONNECTED;
                dbNode.SelectedImageKey = IMAGE_KEY_DATABASE_DISCONNECTED;

                if (DatabaseClosed != null)
                    DatabaseClosed();
            }
        }

        public void CloseSelectedDatabase()
        {
            CloseDatabase(GetSelectedDBNode(tvTree.SelectedNode));
        }

        private void CloseDatabasesOfServer(TreeNode serverNode)
        {
            foreach (TreeNode dbNode in serverNode.Nodes)
            {
                CloseDatabase(dbNode);
            }
        }

        /// <summary>
        /// Return database node by it subnodes
        /// </summary>
        private static TreeNode GetSelectedDBNode(TreeNode node)
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

        private TreeNode ServerToNode(Server server)
        {
            TreeNode nodeHost = new TreeNode()
            {
                Text = server.Address,
                Tag = server,
                ImageKey = IMAGE_KEY_SERVER,
                SelectedImageKey = IMAGE_KEY_SERVER,
                ContextMenuStrip = cmsServer
            };

            foreach (Database db in server.Databases)
            {
                TreeNode nodeDB = new TreeNode()
                {
                    Text = db.Name,
                    Tag = db,
                    ImageKey = IMAGE_KEY_DATABASE_DISCONNECTED,
                    SelectedImageKey = IMAGE_KEY_DATABASE_DISCONNECTED,
                    ContextMenuStrip = cmsDatabase
                };
                nodeHost.Nodes.Add(nodeDB);
            }
            return nodeHost;
        }

        private void RemoveServer(TreeNode serverNode)
        {
            string msg = "Настройки подключения к серверу и его базам данных будут удалены.{0}{0}Продолжить?";
            var res = MessageBox.Show(
                String.Format(msg, Environment.NewLine),
                "Удаление подключения к серверу",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (res == DialogResult.Yes)
            {
                Server server = (Server)serverNode.Tag;

                SuspendLayout();
                CloseDatabasesOfServer(serverNode);
                universe.Servers.Remove(server);
                ConnectionService.CloseSshTunnel(server);
                ConnectionService.Save(universe);
                serverNode.Remove();
                ResumeLayout();
            }
        }

        private void RemoveDatabase(TreeNode dbNode)
        {
            string msg = "Настройки подключения к БД будут удалены.{0}{0}Продолжить?";
            var res = MessageBox.Show(
                String.Format(msg, Environment.NewLine),
                "Удаление подключения к БД",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (res == DialogResult.Yes)
            {
                TreeNode serverNode = dbNode.Parent;
                Server server = (Server)serverNode.Tag;
                Database db = (Database) dbNode.Tag;

                CloseDatabase(dbNode);
                server.Databases.Remove(db);
                ConnectionService.Save(universe);
                dbNode.Remove();
            }
        }

        public void ShowTable(TreeNode node)
        {
            DataTable table = (DataTable)node.Tag;
            TreeNode dbNode = GetSelectedDBNode(node);
            Database db = (Database)dbNode.Tag;
            Server server = (Server)dbNode.Parent.Tag;
            List<Column> columns;

            using (NpgsqlConnection connection = ConnectionService.GetConnection(server, db))
            {
                connection.Open();
                DatabaseService.fetchTableByName(connection, table);
                columns = DatabaseService.fetchTableColumns(connection, table.DataSet.DataSetName, table.TableName);
                table.ExtendedProperties[Database.TABLE_PROPERTY_COLUMNS] = columns;
            }


            // dehilight image of previous opened table
            if (openedTableNode != null)
            {
                openedTableNode.ImageKey = IMAGE_KEY_TABLE;
                openedTableNode.SelectedImageKey = IMAGE_KEY_TABLE;
            }
            // hilight image of selected table
            openedTableNode = node;
            openedTableNode.ImageKey = IMAGE_KEY_TABLE_OPEN;
            openedTableNode.SelectedImageKey = IMAGE_KEY_TABLE_OPEN;

            if (TableOpened != null)
                TableOpened(table);
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

        private void OnSelectTreeNode(TreeNode node)
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

        private void Shutdown()
        {
            if (universe != null)
            {
                foreach (var server in universe.Servers)
                {
                    ConnectionService.CloseSshTunnel(server);
                }
            }
        }

        private void TreeWorkspace_Load(object sender, EventArgs e)
        {
            ilTreeView.Images.Add(IMAGE_KEY_SERVER, Resources.computersystemproduct);
            ilTreeView.Images.Add(IMAGE_KEY_DATABASE_CONNECTED, Resources.Database_Active_icon);
            ilTreeView.Images.Add(IMAGE_KEY_DATABASE_DISCONNECTED, Resources.Database_Inactive_icon);
            ilTreeView.Images.Add(IMAGE_KEY_SCHEMA, Resources.Schema_16xLG);
            ilTreeView.Images.Add(IMAGE_KEY_TABLE, Resources.Table_748);
            ilTreeView.Images.Add(IMAGE_KEY_TABLE_OPEN, Resources.Table_748_Opened);
        }

        private void tvTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                OnSelectTreeNode(e.Node);
            }
        }

        private void tvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged();
        }

        private void tvTree_KeyDown(object sender, KeyEventArgs e)
        {
            bool handled = false;

            if (e.KeyCode == Keys.Enter && tvTree.SelectedNode != null)
            {
                OnSelectTreeNode(tvTree.SelectedNode);
                handled = true;
            }
            else if (e.KeyCode == Keys.Delete && tvTree.SelectedNode != null)
            {
                TreeNode node = tvTree.SelectedNode;
                if (node != null && node.Tag is Server)
                {
                    RemoveServer(node);
                    handled = true;
                }
            }
            else if (e.KeyCode == Keys.Insert)
            {
                if (NewConnection != null)
                    NewConnection();
            }

            if (handled)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void tsmiRemoveServer_Click(object sender, EventArgs e)
        {
            // due to strane behavior we can't use TreeView.SelectedNode here to find out TreeNode for witch context menu is opened
            var hitTest = tvTree.HitTest(tvTree.PointToClient(new Point(cmsServer.Left, cmsServer.Top)));
            var selectedNode = hitTest.Node;

            if (selectedNode != null)
            {
                RemoveServer(selectedNode);
            }
        }

        private void tsmiRemoveDatabase_Click(object sender, EventArgs e)
        {
            // due to strane behavior we can't use TreeView.SelectedNode here to find out TreeNode for witch context menu is opened
            var hitTest = tvTree.HitTest(tvTree.PointToClient(new Point(cmsDatabase.Left, cmsDatabase.Top)));
            var selectedNode = hitTest.Node;

            if (selectedNode != null)
            {
                RemoveDatabase(selectedNode);
            }
        }
    }
}
