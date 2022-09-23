using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CRUD_OPERATIONS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            VBSQLHelper.SQLHelper.SERVER_NAME = "DESKTOP-H25AET7\\SQLEXPRESS";
            VBSQLHelper.SQLHelper.DATABASE = "EmployeeDB";
            VBSQLHelper.SQLHelper.USERNAME_DB = "sa";
            VBSQLHelper.SQLHelper.PASSWORD_DB = "12345";
            VBSQLHelper.SQLHelper.ConnectString();
            Application.Run(new Form1());
        }
    }
}
