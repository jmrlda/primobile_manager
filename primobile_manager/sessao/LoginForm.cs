using primaveraApi.crud;
using primaveraApi.modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace primobile_manager.sessao
{
    public partial class LoginForm : Form
    {

        public Usuario usuario;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }


         private bool adminLog(String nome,  String senha)
        {

            bool rv = false;
            UsuarioCRUD usuario_crud = new UsuarioCRUD();
            usuario = usuario_crud.login(nome, senha);

            if ( usuario != null)  
            {
                rv = true;
            } else
            {
                rv = false;
            }

            return rv;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nome = txtUsuario.Text;
            String senha = txtSenha.Text;

            if ( adminLog(nome, senha) == true )
            {
                
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
