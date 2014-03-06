﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewAutoFilter;
using PgEdit.Domain;

namespace PgEdit
{
    public partial class TableWorkspace : UserControl
    {
        public TableWorkspace()
        {
            InitializeComponent();

            dgvData.AutoGenerateColumns = true;
        }

        public void SetDataSource(object dataSource, string dataMember)
        {
            bsData.DataSource = dataSource;
            bsData.DataMember = dataMember;

            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (!(col.HeaderCell is DataGridViewAutoFilterColumnHeaderCell))
                {
                    var cell = new DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
                    cell.FilteredChanged += HeaderCell_FilteredChanged;
                    col.HeaderCell = cell;
                }
            }

            SetupFilters();
        }

        private DataTable GetBindedTable() {
            DataTable tbl;

            if (bsData.DataSource is DataSet)
            {
                DataSet ds = (DataSet)bsData.DataSource;

                tbl = ds.Tables[bsData.DataMember];
            }
            else if (bsData.DataSource is DataTable)
            {
                tbl = (DataTable)bsData.DataSource;
            }
            else
            {
                throw new InvalidOperationException("Unknown datasource");
            }

            return tbl;
        }

        private void SetupFilters()
        {
            if (bsData.DataSource != null)
            {
                DataTable tbl = GetBindedTable();
                object rowsCount = tbl.ExtendedProperties[Database.TABLE_PROPERTY_ROWS_COUNT];

                tsslRowsCount.Text = string.Format("Записей извлечено: {0} из {1}", bsData.Count, rowsCount);
            }
            else
            {
                tsslRowsCount.Text = null;
            }
        }

        private void HeaderCell_FilteredChanged(object sender, EventArgs e)
        {
            int rows = dgvData.AllowUserToAddRows ? dgvData.Rows.Count - 1 : dgvData.Rows.Count;
            tsslRowsFiltered.Text = "Отфильтровано записей: " + rows;
        }

    }
}
