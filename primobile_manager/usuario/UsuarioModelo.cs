using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primobile_manager.usuario
{
    public class UsuarioModelo
    {
        public String id { get; set; }
        public String nome { get; set; }
        public String senha { get; set; }
        
        public String perfil  { get; set; }
        public String documento { get; set; }

        public UsuarioModelo()
        {

        }

        public UsuarioModelo(String nome, String senha, String perfil, String documento)
        {
            this.nome = nome;
            this.senha = senha;
            this.perfil = perfil;
            this.documento = documento;
        }        

    }
}
