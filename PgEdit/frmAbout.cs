using PgEdit.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgEdit
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            picLogo.Image = Bitmap.FromHicon(Resources.logo.Handle);

            string info = string.Format(
                "Автор: Аншилевич Дмитрий{0}" + 
                "Версия: {1}", 
                Environment.NewLine, 
                Assembly.GetExecutingAssembly().GetName().Version);
            txtInfo.Text = info;
        }
    }
}
