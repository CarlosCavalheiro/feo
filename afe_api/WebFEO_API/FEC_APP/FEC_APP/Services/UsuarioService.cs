using FEC_APP.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FEC_APP.Services
{
    class UsuarioService : WebServiceManager
    {
        private const string URL = "http://fecapi.ddns.net/api/usuario/{0}";

        public async System.Threading.Tasks.Task<Usuario> Autenticar(string email, string senha)
        {
            JObject json = new JObject(new JProperty("Login", email), new JProperty("Senha", senha));

            HttpResponseMessage responseMessage = await ConsumirAPIAsync(string.Format(URL, "login"),
                                                                                            PostType.POST,
                                                                                            json.ToString());
            Usuario usuario = new Usuario();

            if (responseMessage.IsSuccessStatusCode)
            {
                string retorno = await responseMessage.Content.ReadAsStringAsync();

                //JsonSerializerSettings serSettings = new JsonSerializerSettings();
                //serSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                usuario = JsonConvert.DeserializeObject<Usuario>(retorno);   
                usuario.Senha = senha;
                //usuario.TokenRegistrado = JsonConvert.DeserializeObject<Usuario>(retorno).TokenRegistrado;                
                return usuario;
            }
            else
            {
                string retorno = await responseMessage.Content.ReadAsStringAsync();
                JObject jRetorno = JObject.Parse(retorno);
                throw new Exception(jRetorno["message"].ToString());
            }

        }

    }
}
