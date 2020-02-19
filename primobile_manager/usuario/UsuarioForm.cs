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

            if (checkCampos() == true)
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
                else
                {
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

            } else
            {
                MessageBox.Show("Preencher devidamente os campos!");
            }


        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            bloquear_campos();
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
            if ( usuario != null) { 
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

        }

        // verificar se os campos estao preenchidos
        private bool checkCampos()
        {

            bool rv = false;
            Color color_bkp = new Color();
 
            color_bkp = txtId.BackColor;

            if (txtNome.TextLength > 0 &&  txtSenha.TextLength > 0 && cboDocumento.SelectedIndex > 0 && cboPerfil.SelectedIndex > 0 )
            {
                rv = true;
            } 


            if (txtNome.TextLength < 3)
            {
                txtNome.BackColor = Color.Red;
                rv = false;
                lblNome.Visible = true;
            } else
            {
                txtNome.BackColor = color_bkp;
                lblNome.Visible = false;

            }


            if (txtSenha.TextLength < 6)
            {
                txtSenha.BackColor = Color.Red;
                rv = false;
                lblSenha.Visible = true;
            }
            else
            {
                txtSenha.BackColor = color_bkp;
                lblSenha.Visible = false;

            }




            if (cboDocumento.SelectedIndex <= 0)
            {
                cboDocumento.BackColor = Color.Red;
                rv = false;
                lblDocumento.Visible = true;
            }
            else
            {
                cboDocumento.BackColor = color_bkp;
                lblDocumento.Visible = false;
            }

            if (cboPerfil.SelectedIndex <= 0)
            {
                cboPerfil.BackColor = Color.Red;
                rv = false;
                lblPerfil.Visible = true;
            }
            else
            {
                cboPerfil.BackColor = color_bkp;
                lblPerfil.Visible = false;

            }


            return rv;

        }

        


        // Eventos

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario_lista_form.ShowDialog(this);
            usuario = usuario_lista_form.usuario;
            if (usuario != null)
            {
                preecher_campo(usuario);

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            desbloquear_campos();
            limpar_campo();

        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpar_campo();
            desbloquear_campos();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
