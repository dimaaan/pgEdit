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

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            StringBuilder displayVersion = new StringBuilder(32);

            displayVersion.Append(version.Major);
            displayVersion.Append('.');
            displayVersion.Append(version.Minor);

            if(version.Build != 0) {
                displayVersion.Append('.');
                displayVersion.Append(version.Build);
            }
            
            string info = string.Format(
                "Автор: Аншилевич Дмитрий{0}" + 
                "Версия: {1}{0}{0}" +
                "Компоненты:{0}" +
                "* Npgsql https://github.com/npgsql/Npgsql{0}" +
                "* SSH.NET http://sshnet.codeplex.com/{0}" +
                "* DataGridViewAutoFilterColumnHeaderCell http://msdn.microsoft.com/en-us/library/aa480727.aspx", 
                Environment.NewLine,
                displayVersion);
            txtInfo.Text = info;
        }
    }
}
