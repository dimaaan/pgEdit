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
                "* Npgsql{0}https://github.com/npgsql/Npgsql{0}" +
                "* SSH.NET{0}http://sshnet.codeplex.com{0}" +
                "* JSON.NET{0}http://json.codeplex.com{0}" +
                "* DataGridViewAutoFilterColumnHeaderCell{0}http://msdn.microsoft.com/en-us/library/aa480727.aspx{0}" +
                "* BindingListView{0}https://github.com/waynebloss/BindingListView " +
                "{0}{0}" + 
                "Арт:{0} " +
                "Логотип - Анна \"annubis\" Кикош", 
                Environment.NewLine,
                displayVersion);
            txtInfo.Text = info;
        }
    }
}
