using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgEdit
{
    public partial class TableWorkspace : UserControl
    {
        public IBindingListView DataSource
        {
            get
            {
                return (IBindingListView) dgvColumns.DataSource;
            }
            set
            {
                dgvColumns.DataSource = value;
            }
        }

        public TableWorkspace()
        {
            InitializeComponent();
        }
    }
}
