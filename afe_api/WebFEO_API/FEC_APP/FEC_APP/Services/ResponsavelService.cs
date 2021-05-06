using FEC_APP.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FEC_APP.Services
{
    class ResponsavelService : WebServiceManager
    {

        private const string URL = "http://fecapi.ddns.net/api/responsavel/{0}";

        private Usuario usuario = null;
        private async Task<bool> UsuarioValido()
        {
            UsuarioService usuarioService = new UsuarioService();

            Usuario _usuario = AppService.UsuarioRegistrado();
            //Verificar se têm token ativo
            if (_usuario.TokenRegistrado == null)
            {
                _usuario = await usuarioService.Autenticar(usuario.Login, usuario.Senha);
                AppService.RegistrarLogin(ref _usuario);
                usuario = _usuario;
            }
            this.usuario = _usuario;
            return _usuario == null ? false : true;
        }

        public async Task<List<Responsavel>> Listar()
        {
            if (await UsuarioValido())
            {
                HttpResponseMessage responseMessage = await ConsumirAPIAsync(string.Format(URL, ""),
                                                                                    PostType.GET, null,                                                                                    
                                                                                    usuario.TokenRegistrado);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string retorno = await responseMessage.Content.ReadAsStringAsync();

                    List<Responsavel> listaResponsavel = JsonConvert.DeserializeObject<List<Responsavel>>(retorno);

                    return listaResponsavel;
                }
                else
                {
                    string retorno = await responseMessage.Content.ReadAsStringAsync();
                    JObject jRetorno = JObject.Parse(retorno.ToString());
                    throw new Exception(jRetorno["message"].ToString());
                }
            }
            else
                throw new Exception("Não foi possível obter a chave de validação");
        }

    }
}
