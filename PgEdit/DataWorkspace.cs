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
using PgEdit.GridFilter;

namespace PgEdit
{
    /// <remarks>
    /// Subscribing to DataSourceNeedRefresh required
    /// </remarks>
    public partial class DataWorkspace : UserControl
    {
        /// <summary>
        /// Table for BindingDataSource
        /// </summary>
        private DataTable currentDataSource;

        public DataTable DataSource
        {
            get
            {
                return currentDataSource;
            }
            set
            {
                if (value != null)
                {
                    if (currentDataSource != value)
                    {
                        bsData.Filter = null;
                    }
                    bsData.DataSource = value;

                    object rowsCount = value.ExtendedProperties[Database.TABLE_PROPERTY_ROWS_COUNT];
                    tsslRowsCount.Text = string.Format("Записей извлечено: {0} из {1}", bsData.Count, rowsCount);
                    tsbRefresh.Enabled = tsmiRefresh.Enabled = true;
                }
                else
                {
                    bsData.DataSource = null;
                    bsData.Filter = null;
                    tsslRowsCount.Text = null;
                    tsbRefresh.Enabled = tsmiRefresh.Enabled = false;
                }

                currentDataSource = value;
            }
        }

        /// <summary>
        /// Raises when Refresh button pushed
        /// </summary>
        public event Action DataSourceNeedRefresh;

        public DataWorkspace()
        {
            InitializeComponent();

            dgvData.AutoGenerateColumns = true;
            tsslOffsetLimit.Text = string.Format("LIMIT {0} OFFSET 0", DatabaseService.ROWS_LIMIT);
        }

        private void HeaderCell_FilteredChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(bsData.Filter))
            {
                int rows = dgvData.AllowUserToAddRows ? dgvData.Rows.Count - 1 : dgvData.Rows.Count;
                tsslRowsFiltered.Text = "Отфильтровано записей: " + rows;
                lblFilterExpr.Text = bsData.Filter;
                panFilters.Visible = true;
            }
            else
            {
                tsslRowsFiltered.Text = null;
                panFilters.Visible = false;
            }
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            bsData.Filter = null;
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            DataSourceNeedRefresh();
        }

        private void dgvData_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            var cell = new DataGridViewAutoFilterColumnHeaderCell(e.Column.HeaderCell);
            cell.FilteredChanged += HeaderCell_FilteredChanged;
            e.Column.HeaderCell = cell;
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Display)
            {
                e.ThrowException = false;
            }
        }
    }
}
