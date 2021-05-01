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
    class AlunoService : WebServiceManager
    {

        private const string URL = "http://fecapi.ddns.net/api/aluno/{0}";

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
            return (_usuario == null ? false : true);
        }

        public async Task<List<Aluno>> Listar()
        {
            if (await UsuarioValido())
            {
                HttpResponseMessage responseMessage = await ConsumirAPIAsync(string.Format(URL),
                                                                                    PostType.GET,
                                                                                    "",
                                                                                    usuario.TokenRegistrado);

                List<Aluno> listaAlunos = new List<Aluno>();

                if (responseMessage.IsSuccessStatusCode)
                {
                    string retorno = await responseMessage.Content.ReadAsStringAsync();

                    listaAlunos = JsonConvert.DeserializeObject<List<Aluno>>(retorno);

                    return listaAlunos;
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
