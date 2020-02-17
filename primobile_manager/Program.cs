using primobile_manager.usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace primobile_manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UsuarioForm usuario_form = new UsuarioForm();
            MenuForm menu = new MenuForm();
            Application.Run(menu);
        }
    }
}
