using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgEdit.GridFilter
{
    /// <summary>
    /// Where-like filter for DataGridView string columns.
    /// </summary>
    /// <remarks>
    /// Create it ONLY with param constructor
    /// </remarks>
    public partial class frmFilterString : Form, IFIlterForm
    {
        /// <summary>
        /// Field, that needs to be sorted
        /// </summary>
        private string Field;

        private const string FILTER_TYPE_EQUALS = "равняется";
        private const string FILTER_TYPE_NOT_EQUALS = "не равняется";
        private const string FILTER_TYPE_LIKE = "похоже на";
        private const string FILTER_TYPE_NOT_LIKE = "не похоже на";

        private string[] filterTypes = { FILTER_TYPE_EQUALS, FILTER_TYPE_NOT_EQUALS, FILTER_TYPE_LIKE, FILTER_TYPE_NOT_LIKE };


        public frmFilterString()
        {
            InitializeComponent();
        }

        public frmFilterString(string field)
            : this()
        {
            this.Field = field;

            lblFiledName.Text = Field;

            cmbOperand.Items.AddRange(filterTypes);
            cmbOperand.SelectedItem = FILTER_TYPE_LIKE;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cmbOperand_SelectedValueChanged(object sender, EventArgs e)
        {
            object selItem = cmbOperand.SelectedItem;

            panInfo.Visible = selItem == (object)FILTER_TYPE_LIKE || selItem == (object)FILTER_TYPE_NOT_LIKE;
        }

        public string Filter
        {
            get
            {
                string value = cmbValue.Text;
                string result = String.Empty;

                if (!String.IsNullOrWhiteSpace(value))
                {
                    switch (cmbOperand.Text)
                    {
                        case FILTER_TYPE_EQUALS:
                            result = String.Format("[{0}]='{1}'", Field, value);
                            break;
                        case FILTER_TYPE_NOT_EQUALS:
                            result = String.Format("[{0}]<>'{1}'", Field, value);
                            break;
                        case FILTER_TYPE_LIKE:
                            result = String.Format("[{0}] LIKE '{1}'", Field, value);
                            break;
                        case FILTER_TYPE_NOT_LIKE:
                            result = String.Format("[{0}] NOT LIKE '{1}'", Field, value);
                            break;
                        default:
                            throw new InvalidOperationException("Unknown filter type " + cmbOperand.Text);
                    }
                }

                return result;
            }
        }
    }
}
