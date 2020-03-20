using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using primaveraApi.modelo;
using primobile_manager.usuario;
namespace primobile_manager.network
{
    class ClienteApi
    {
        public Usuario usuario_modelo;
        public JavaScriptSerializer js;

        public ClienteApi()
        {
            usuario_modelo = new Usuario();
            js = new JavaScriptSerializer();
        }

         public ClienteApi(Usuario usuario)
        {
            usuario_modelo = usuario;
            js = new JavaScriptSerializer();    
        }


        public void criar_request(String url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            string json_data = js.Serialize(this.usuario_modelo);

           
            // escrever dados no request stream
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(json_data);
            }

            // obter a resposta do servidor

            using( WebResponse response = request.GetResponse())
            {
                Stream response_stream = response.GetResponseStream();
                using(StreamReader reader = new StreamReader(response_stream))
                {
                    Console.Write(reader.ReadToEnd()); 
                }
            }
        }


        public bool is_usuario_sincronizado(String url)
        {
            bool rv = false;
            String json_rv = null;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            

            //ler dados enviados pelo servidor
            using (WebResponse response = request.GetResponse())
            {
                Stream response_stream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(response_stream))
                {

                    json_rv = reader.ReadToEnd();
                    Object val = js.Deserialize<Object>(json_rv);
                    //js.Serialize(this.usuario_modelo);
                }
            }


            return rv;
        }



    }
}
