using primaveraApi.modelo;
using primobile_manager.sessao;
using primobile_manager.usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace primobile_manager
{
    public partial class MenuForm : Form
    {
        Usuario usuario_logado = new Usuario();
        public MenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new UsuarioForm().ShowDialog(this);
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog(this);
            usuario_logado = login.usuario;
            if (usuario_logado == null)
            {
                this.Close();
            }
            else

            if (usuario_logado.nivel.ToLower() != "admin" && usuario_logado.nivel.ToLower() != "super_admin")
            {
                MessageBox.Show("Entrada somente a usuarios autorizados!");
                this.Close();
            }
            else
            {

                toolStribUsuario.Text = usuario_logado.nome;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
