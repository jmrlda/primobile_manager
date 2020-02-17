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

namespace primobile_manager.usuario
{
    public partial class UsuarioForm : Form
    {
        Usuario usuario = new Usuario();
        UsuarioLista usuario_lista_form = new UsuarioLista();
        public UsuarioForm()
        {
            InitializeComponent();
               this.cboDocumento.SelectedIndex = 0;
            this.cboPerfil.SelectedIndex = 0;

        }

        private void cboDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String id = txtId.Text;
            String nome = txtNome.Text;
            String senha = txtSenha.Text;
            String perfil = cboPerfil.GetItemText(cboPerfil.SelectedItem);
            String documento = cboDocumento.GetItemText(cboDocumento.SelectedItem);

            UsuarioCRUD usuarioCrud = new UsuarioCRUD();
            Usuario _usuario = new Usuario();
            if (id.Length > 5)
            {
                _usuario = new Usuario(id, nome, senha, documento, perfil);
                bool rv = usuarioCrud.update(_usuario);

                if (rv == true)
                {
                    MessageBox.Show("Usuario actualizado com sucesso");
                    limpar_campo();
                    bloquear_campos();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro de actualizacao");

                }

            }
            else {
                _usuario = new Usuario(nome, senha, documento, perfil);
                bool rv = usuarioCrud.create(_usuario);

                if (rv == true)
                {
                    MessageBox.Show("Usuario Salvo com sucesso");
                    limpar_campo();
                    bloquear_campos();

                }
                else
                {
                    MessageBox.Show("Ocorreu um erro");

                }


            }


        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }



        // Bloquear campos do formulario
        private void bloquear_campos()
        {
            this.txtId.Enabled = false;
            this.txtNome.Enabled = false;
            this.txtSenha.Enabled = false;
            this.cboDocumento.Enabled = false;
            this.cboPerfil.Enabled = false;
            btnSalvar.Enabled = false;
        }


        // Desbloquear campos do formulario
        private void desbloquear_campos()
        {
            this.txtId.Enabled = true;
            this.txtNome.Enabled = true;
            this.txtSenha.Enabled = true;
            this.cboDocumento.Enabled = true;
            this.cboPerfil.Enabled = true;
            btnSalvar.Enabled = true;

        }


        // Limpar campos do formulario
        private void limpar_campo()
        {
            this.txtId.Text = "";
            this.txtNome.Text = "";
            this.txtSenha.Text = "";
            this.cboDocumento.SelectedIndex = 0;
            this.cboPerfil.SelectedIndex = 0;
        }

        private void preecher_campo(Usuario _usuario)
        {
            txtId.Text = _usuario.usuario;
            txtNome.Text = _usuario.nome;
            txtSenha.Text = _usuario.senha;

            int index;

            if (_usuario.nivel == "bloqueado")
            {
                cboPerfil.Text = "bloqueado";
                cboPerfil.Enabled = false;
                btnSalvar.Enabled = false;
                bloquear_campos();
            } else {
                index = cboPerfil.Items.IndexOf(_usuario.nivel);
                cboPerfil.SelectedIndex = index;
                btnSalvar.Enabled = true;

            }

            index = cboDocumento.Items.IndexOf(_usuario.documento);
            cboDocumento.SelectedIndex = index;

        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario_lista_form.ShowDialog(this);
            usuario = usuario_lista_form.usuario;
            preecher_campo(usuario);
            MessageBox.Show(usuario.nome);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            desbloquear_campos();
            this.btnEditar.Enabled = false;

        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpar_campo();
            desbloquear_campos();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
