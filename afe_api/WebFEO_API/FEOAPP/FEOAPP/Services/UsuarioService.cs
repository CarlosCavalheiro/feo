using FEOAPP.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FEOAPP.Services
{
    class UsuarioService : WebServiceManager
    {
        private const string URL = "https://feoapi.ddns.net/api/api/usuarios/{0}";

        public async System.Threading.Tasks.Task<Usuario> ChecarLogin(string login)
        {
            JObject json = new JObject(new JProperty("login", login));

            HttpResponseMessage responseMessage = await ConsumirAPIAsync(string.Format(URL, "checarlogin"),
                                                                                            PostType.POST,
                                                                                            json.ToString());

            if (responseMessage.IsSuccessStatusCode)
            {
                string retorno = await responseMessage.Content.ReadAsStringAsync();

                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(retorno);
                return usuario;
            }
            else
            {
                string retorno = await responseMessage.Content.ReadAsStringAsync();
                JObject jRetorno = JObject.Parse(retorno);
                throw new Exception(jRetorno["message"].ToString());
            }

        }

        public async System.Threading.Tasks.Task<Usuario> Autenticar(string email, string senha)
        {
            JObject json = new JObject(new JProperty("email", email), new JProperty("senha", senha));

            HttpResponseMessage responseMessage = await ConsumirAPIAsync(string.Format(URL, "login"),
                                                                                            PostType.POST,
                                                                                            json.ToString());

            if (responseMessage.IsSuccessStatusCode)
            {
                string retorno = await responseMessage.Content.ReadAsStringAsync();

                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(retorno);
                usuario.Senha = senha;
                return usuario;
            }
            else
            {
                string retorno = await responseMessage.Content.ReadAsStringAsync();
                JObject jRetorno = JObject.Parse(retorno);
                throw new Exception(jRetorno["message"].ToString());
            }

        }

        public async System.Threading.Tasks.Task<Usuario> Criar(Usuario usuario)
        {

            string json = JsonConvert.SerializeObject(usuario);

            HttpResponseMessage responseMessage = await ConsumirAPIAsync(string.Format(URL, ""),
                                                                                            PostType.POST,
                                                                                            json.ToString());

            if (responseMessage.IsSuccessStatusCode)
            {
                string retorno = await responseMessage.Content.ReadAsStringAsync();
                string senha = usuario.Senha;

                usuario = JsonConvert.DeserializeObject<Usuario>(retorno);

                usuario.Senha = senha;

                return usuario;
            }
            else
            {
                string retorno = await responseMessage.Content.ReadAsStringAsync();
                JObject jRetorno = JObject.Parse(retorno.ToString());
                throw new Exception(jRetorno["message"].ToString());
            }

        }

        public async System.Threading.Tasks.Task<Usuario> Alterar(Usuario usuario)
        {

            Usuario _usuario = AppService.UsuarioRegistrado();
            //Verificar se têm token ativo
            if (_usuario.Token == null || _usuario.TokenValidade <= DateTime.Now)
                _usuario = await this.Autenticar(usuario.Login, usuario.Senha);

            if (usuario != null)
            {
                string json = JsonConvert.SerializeObject(usuario);

                HttpResponseMessage responseMessage = await ConsumirAPIAsync(string.Format(URL, usuario.Id.ToString()),
                                                                                                PostType.PUT,
                                                                                                json.ToString(),
                                                                                                _usuario.Token);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string retorno = await responseMessage.Content.ReadAsStringAsync();

                    usuario = JsonConvert.DeserializeObject<Usuario>(retorno);

                    return usuario;
                }
                else
                {
                    string retorno = await responseMessage.Content.ReadAsStringAsync();
                    JObject jRetorno = JObject.Parse(retorno.ToString());
                    throw new Exception(jRetorno["message"].ToString());
                }
            }
            else
                throw new Exception("Token inválido");
        }
    }
}
