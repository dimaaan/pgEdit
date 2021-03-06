﻿using Equin.ApplicationFramework;
using Npgsql;
using PgEdit.Domain;
using PgEdit.Properties;
using PgEdit.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private void RefreshMenu()
        {
            Database selDb = ucTree.SelectedDatabase;
            Server selServ = ucTree.SelectedServer;

            tsmiConnect.Enabled = selDb != null && !selDb.IsOpen;
            tsmiDisconnect.Enabled = selDb != null && selDb.IsOpen;
            tsmiRemoveDatabase.Enabled = selDb != null;
            tsmiRemoveServer.Enabled = selServ != null;
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

        private void ShowNewConnectionDialog()
        {
            frmConnection dlg = new frmConnection(universe);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Server mergedServer = ConnectionService.MergeServer(universe.Servers, dlg.Server);
                Database newDb = dlg.Server.Databases.First();

                if (mergedServer == null)
                {
                    ucTree.AddServer(dlg.Server);
                    ucTree.SelectDatabase(newDb);
                }
                else
                {
                    ucTree.AddDatabase(mergedServer, newDb);
                    ucTree.SelectDatabase(newDb);
                }

                ConnectionService.Save(universe);
            }
        }

        private void ShowViewConnectionDialog(Server server, Database db)
        {
            new frmConnection(universe, server, db).ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Icon = Resources.logo;

            universe = ConnectionService.Load();

            ucTree.Universe = universe;
            if (universe.Servers.Count > 0)
            {
                ucTree.FillTreeView();
            }
            else
            {
                ShowNewConnectionDialog();
            }
        }

        private void tsmiNewConnection_Click(object sender, EventArgs e)
        {
            ShowNewConnectionDialog();
        }

        private void tsmiConnect_Click(object sender, EventArgs e)
        {
            ucTree.OpenSelectedDatabase();
        }

        private void tsmiDisconnect_Click(object sender, EventArgs e)
        {
            ucTree.CloseSelectedDatabase();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();

            frm.ShowDialog();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiRegisteredDB_Click(object sender, EventArgs e)
        {
            Process.Start("ConnectionStrings.json");
        }

        private void tsmiRemoveDatabase_Click(object sender, EventArgs e)
        {
            ucTree.RemoveDatabase(ucTree.SelectedNode);
        }

        private void tsmiRemoveServer_Click(object sender, EventArgs e)
        {
            ucTree.RemoveServer(ucTree.SelectedNode);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Shutdown();
        }

        private void ucTable_DataSourceNeedRefresh()
        {
            ucTree.ShowTable(ucTree.OpenedTableNode);
        }

        private void ucTree_DatabaseOpened()
        {
            RefreshMenu();
        }

        private void ucTree_DatabaseClosed()
        {
            ucTable.DataSource = null;
            ucTable.Tag = null;
            ucColumns.DataSource = null;
            RefreshMenu();
        }

        private void ucTree_TableOpened(DataTable table)
        {
            List<Column> columns = (List<Column>) table.ExtendedProperties[Database.TABLE_PROPERTY_COLUMNS];
            ucColumns.DataSource = new BindingListView<Column>(columns);
            ucTable.DataSource = table;
        }

        private void ucTree_SelectionChanged()
        {
            RefreshMenu();
        }

        private void ucTree_NewConnection()
        {
            ShowNewConnectionDialog();
        }

        private void ucTree_ViewConnection(Server server, Database db)
        {
            ShowViewConnectionDialog(server, db);
        }
    }
}
