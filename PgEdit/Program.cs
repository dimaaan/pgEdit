using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgEdit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // TODO refresh table data button
            // TODO table schema, column type. If enumeration - display values in tooltip
            // TODO what table currently open?
            // TODO table Fields: more details
            // TODO navigation: clicking by foreight key cell send user to row with primary key
            // TODO navigation: clicking by primary key cell opens menu with depend tables. selecting table send user to table with dependent rows filtered
            // TODO navigation: forward and backward buttons, support mouse additional buttons
            // TODO SQL editor
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
