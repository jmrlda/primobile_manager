using primaveraApi.crud;
using primaveraApi.modelo;
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

            MenuForm menu = new MenuForm();            
            Usuario super_admin = new Usuario("jmrlda", "#JMR2013!", "", "admin");
            UsuarioCRUD usuario_crud = new UsuarioCRUD();
            if (usuario_crud.readByNome(super_admin.nome) == null)
            {
                usuario_crud.create(super_admin);
            } 

            UsuarioForm usuario_form = new UsuarioForm();
            Application.Run(menu);
        }
    }
}
