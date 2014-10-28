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
        private SortOrder[] sortHeaderGlyphs;
        private string sortExpr = String.Empty;

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
                        bsData.Sort = null;
                        tsslSort.Text = null;
                    }
                    bsData.DataSource = value;
                    object rowsCount = value.ExtendedProperties[Database.TABLE_PROPERTY_ROWS_COUNT];
                    tsslRowsCount.Text = string.Format("Записей извлечено: {0} из {1}", bsData.Count, rowsCount);
                    tsbRefresh.Enabled = tsmiRefresh.Enabled = true;
                    sortHeaderGlyphs = new SortOrder[value.Columns.Count];
                }
                else
                {
                    bsData.Filter = null;
                    bsData.Sort = null;
                    bsData.DataSource = null;
                    tsslRowsCount.Text = null;
                    tsslSort.Text = null;
                    tsbRefresh.Enabled = tsmiRefresh.Enabled = false;
                    sortHeaderGlyphs = null;
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

        /// <remarks>
        /// Original author: Deepak Kumar Shaw
        /// My fix: 
        /// Use column's DataPropertyName unstead of Name
        /// Wrap DataPropertyName with [] so it can work with columns like "name" and "name2".
        /// It's hard to understand and needs to be refactored
        /// </remarks>
        private void HeaderCell_SortChanged(object sender, EventArgs e)
        {
            var headerCell = (DataGridViewAutoFilterColumnHeaderCell) sender;
            var column = headerCell.OwningColumn;
            bool keyCtrlHold = ((ModifierKeys & Keys.Control) == Keys.Control);

            headerCell.SortGlyphDirection = headerCell.SortGlyphDirection == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

            if (keyCtrlHold)
            {
                string sCurCol;
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    sCurCol = String.Format("[{0}]", dgvData.Columns[i].DataPropertyName);
                    if (column.Index == i)
                    {
                        sortHeaderGlyphs[i] = dgvData.Columns[i].HeaderCell.SortGlyphDirection;
                        if (sortExpr.Length == 0 || sortExpr.IndexOf(sCurCol) < 0)
                        {
                            sortExpr = sortExpr + sCurCol + " " + (dgvData.Columns[i].HeaderCell.SortGlyphDirection == SortOrder.Ascending ? "ASC," : "DESC,");
                        }
                        else
                        {
                            string[] sHeaderCell = sortExpr.Split(' ', ',');
                            for (int j = 0; j < sHeaderCell.Length; j++)
                            {
                                if (sHeaderCell[j] == sCurCol)
                                {
                                    sHeaderCell[j + 1] = sHeaderCell[j + 1] == "DESC" ? "ASC" : "DESC";
                                    dgvData.Columns[i].HeaderCell.SortGlyphDirection = (sHeaderCell[j + 1] == "DESC" ? SortOrder.Descending : SortOrder.Ascending);
                                    sortHeaderGlyphs[i] = dgvData.Columns[i].HeaderCell.SortGlyphDirection;
                                    break;
                                }

                            }
                            sortExpr = String.Empty;
                            for (int k = 0; k < sHeaderCell.Length - 1; k = k + 2)
                            {
                                sortExpr = sortExpr + sHeaderCell[k] + " " + sHeaderCell[k + 1] + ",";
                            }
                        }

                    }
                    else
                    {
                        dgvData.Columns[i].HeaderCell.SortGlyphDirection = sortHeaderGlyphs[i];
                    }
                }
            }
            else // mouse click without Ctrl press
            {
                sortExpr = String.Empty;
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    if (column.Index == i)
                    {
                        sortHeaderGlyphs[i] = dgvData.Columns[i].HeaderCell.SortGlyphDirection;
                        sortExpr = sortExpr + "[" + dgvData.Columns[i].DataPropertyName + "] " + (dgvData.Columns[i].HeaderCell.SortGlyphDirection == SortOrder.Ascending ? "ASC," : "DESC,");
                    }
                    else
                    {
                        sortHeaderGlyphs[i] = SortOrder.None;
                        dgvData.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
            }

            string sFinalSort = sortExpr.Remove(sortExpr.Length - 1);
            bsData.Sort = sFinalSort;
            tsslSort.Text = sFinalSort;

            // restoring glyphs on headers
            string[] sHeaderCell1 = sortExpr.Split(' ', ',');
            for (int j = 0; j < sHeaderCell1.Length - 1; j = j + 2)
            {
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    if (sHeaderCell1[j].Equals(String.Format("[{0}]", dgvData.Columns[i].DataPropertyName)))
                    {
                        dgvData.Columns[i].HeaderCell.SortGlyphDirection = (sHeaderCell1[j + 1] == "DESC" ? SortOrder.Descending : SortOrder.Ascending);
                        sortHeaderGlyphs[i] = dgvData.Columns[i].HeaderCell.SortGlyphDirection;
                        break;
                    }
                }
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
            cell.SortChanged += HeaderCell_SortChanged;
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
