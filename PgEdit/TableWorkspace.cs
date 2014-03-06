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

namespace PgEdit
{
    public partial class TableWorkspace : UserControl
    {
        public TableWorkspace()
        {
            InitializeComponent();

            dgvData.AutoGenerateColumns = true;
        }

        public Object DataSource
        {
            get
            {
                return bsTable.DataSource;
            }
            set
            {
                bsTable.DataSource = value;
            }
        }

        public string DataMember
        {
            get
            {
                return bsTable.DataMember;
            }
            set
            {
                bsTable.DataMember = value;
            }
        }

        private void SetupFilters()
        {
            if (dgvData.DataSource != null)
            {
                bool resize = false;

                foreach (DataGridViewColumn col in dgvData.Columns)
                {
                    if (!(col.HeaderCell is DataGridViewAutoFilterColumnHeaderCell))
                    {
                        col.HeaderCell = new DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
                        resize = true;
                    }
                }

                if (resize)
                {
                    dgvData.AutoResizeColumns();
                }
            }
        }

        private void dgvData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetupFilters();
        }
    }
}
