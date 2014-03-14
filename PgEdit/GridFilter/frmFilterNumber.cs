﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgEdit.GridFilter
{
    public partial class frmFilterNumber : Form, IFIlterForm
    {
        /// <summary>
        /// Field, that needs to be sorted
        /// </summary>
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

        private readonly NumberFormatInfo numberFormatInfo;
        private readonly string decimalSeparator;
        private readonly string groupSeparator;
        private readonly string negativeSign;


        public frmFilterNumber()
        {
            InitializeComponent();
        }

        public frmFilterNumber(string field) 
            : this()
        {
            this.Field = field;

            lblFiledName.Text = Field;

            cmbOperand.Items.AddRange(filterTypes);
            cmbOperand.SelectedItem = FILTER_TYPE_EQUALS;

            numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            groupSeparator = numberFormatInfo.NumberGroupSeparator;
            negativeSign = numberFormatInfo.NegativeSign;
        }

        public string Filter
        {
            get
            {
                string value = txtValue.Text;
                string result = String.Empty;

                if (!String.IsNullOrWhiteSpace(value))
                {
                    switch (cmbOperand.Text)
                    {
                        case FILTER_TYPE_EQUALS:
                            result = String.Format("[{0}]={1}", Field, value);
                            break;
                        case FILTER_TYPE_NOT_EQUALS:
                            result = String.Format("[{0}]<>{1}", Field, value);
                            break;
                        case FILTER_TYPE_LESS:
                            result = String.Format("[{0}]<{1}", Field, value);
                            break;
                        case FILTER_TYPE_LESS_OR_EQUAL:
                            result = String.Format("[{0}]<={1}", Field, value);
                            break;
                        case FILTER_TYPE_GREATER:
                            result = String.Format("[{0}]>{1}", Field, value);
                            break;
                        case FILTER_TYPE_GREATER_OR_EQUAL:
                            result = String.Format("[{0}]>={1}", Field, value);
                            break;
                        default:
                            throw new InvalidOperationException("Unknown filter type " + cmbOperand.Text);
                    }
                }

                return result;
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            string keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (
                keyInput.Equals(decimalSeparator) || 
                keyInput.Equals(groupSeparator) ||
                keyInput.Equals(negativeSign))
            {
                // Decimal separator is OK
            }
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtValue.Text))
            {
                // ensure user input is digit

                decimal tst;

                if (decimal.TryParse(txtValue.Text, out tst))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Введите число");
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
