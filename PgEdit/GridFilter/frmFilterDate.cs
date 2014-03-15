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
    public partial class frmFilterDate : Form, IFIlterForm
    {
        private string Field;

        private const string FILTER_TYPE_EQUALS = "равняется";
        private const string FILTER_TYPE_NOT_EQUALS = "не равняется";
        private const string FILTER_TYPE_LESS = "меньше чем";
        private const string FILTER_TYPE_LESS_OR_EQUAL = "меньше чем или равно";
        private const string FILTER_TYPE_GREATER = "больше чем";
        private const string FILTER_TYPE_GREATER_OR_EQUAL = "больше чем или равно";

        private string[] filterTypes = { 
                                           FILTER_TYPE_EQUALS, 
                                           FILTER_TYPE_NOT_EQUALS, 
                                           FILTER_TYPE_LESS, 
                                           FILTER_TYPE_LESS_OR_EQUAL, 
                                           FILTER_TYPE_GREATER, 
                                           FILTER_TYPE_GREATER_OR_EQUAL 
                                       };

        public frmFilterDate()
        {
            InitializeComponent();
        }

        public frmFilterDate(string field)
            : this()
        {
            this.Field = field;

            lblFiledName.Text = Field;

            cmbOperand.Items.AddRange(filterTypes);
            cmbOperand.SelectedItem = FILTER_TYPE_EQUALS;
        }

        public string Filter
        {
            get 
            {
                string result = String.Empty;
                string value = dtpValue.Value.ToString("MM/dd/yyyy");

                switch (cmbOperand.Text)
                {
                    case FILTER_TYPE_EQUALS:
                        result = String.Format("[{0}]=#{1}#", Field, value);
                        break;
                    case FILTER_TYPE_NOT_EQUALS:
                        result = String.Format("[{0}]<>#{1}#", Field, value);
                        break;
                    case FILTER_TYPE_LESS:
                        result = String.Format("[{0}]<#{1}#", Field, value);
                        break;
                    case FILTER_TYPE_LESS_OR_EQUAL:
                        result = String.Format("[{0}]<=#{1}#", Field, value);
                        break;
                    case FILTER_TYPE_GREATER:
                        result = String.Format("[{0}]>#{1}#", Field, value);
                        break;
                    case FILTER_TYPE_GREATER_OR_EQUAL:
                        result = String.Format("[{0}]>=#{1}#", Field, value);
                        break;
                    default:
                        throw new InvalidOperationException("Unknown filter type " + cmbOperand.Text);
                }

                return result;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
