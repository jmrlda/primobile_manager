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
    public partial class UsuarioLista : Form
    {

        List<Usuario> lista_usuario;
        public Usuario usuario;
        public UsuarioLista()
        {
            InitializeComponent();
        }

        private void UsuarioLista_Load(object sender, EventArgs e)
        {

            UsuarioCRUD usuarioCrud = new UsuarioCRUD();
           lista_usuario = usuarioCrud.read();
            dgvUsuario.Rows.Clear();
            lista_usuario.ForEach(delegate (Usuario _usuario)
            {
                dgvUsuario.Rows.Add(_usuario.usuario, _usuario.nome, _usuario.nivel, _usuario.documento);

            });

        }

        private void dgvUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dgvUsuario.Rows[rowIndex];
            String id = row.Cells[0].Value.ToString();
            lista_usuario.ForEach(delegate (Usuario u)
            {
                if ( u.usuario == id)
                {
                    usuario = u;
                    this.Close();

                }
            });

        }
    }
}
