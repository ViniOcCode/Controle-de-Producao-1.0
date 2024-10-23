using ControleProdForms.Presenters;
using ControleProdForms.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleProdForms
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = @"DataSource=..\..\Bin\Files\database.db; Version=3;";
            Database.Iniciar(sqlConnectionString);
            IMenuView view = new MenuView();
            new MenuPresenter(view, sqlConnectionString);
            Application.Run((Form)view);
        }
    }
}
