using System;
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
                foreach (DataGridViewColumn col in dgvData.Columns)
                {
                    if (!(col.HeaderCell is DataGridViewAutoFilterColumnHeaderCell))
                    {
                        col.HeaderCell = new DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
                    }
                }

                DataTable tbl = GetBindedTable();
                object rowsCount = tbl.ExtendedProperties[Database.TABLE_PROPERTY_ROWS_COUNT];

                tsslRowsCount.Text = string.Format("Записей извлечено: {0} из {1}", bsData.Count, rowsCount);
            }
            else
            {
                tsslRowsCount.Text = null;
                tsslRowsFiltered.Text = null;
            }
                
        }

    }
}
