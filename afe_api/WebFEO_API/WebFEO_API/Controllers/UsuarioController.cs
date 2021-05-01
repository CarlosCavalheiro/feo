using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebFEO_API.Models;
using WebFEO_API.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using WebFEO_API.Services;

namespace WebFEO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        public UsuarioController(AppDb db)
        {
            Db = db;
        }

        // GET api/usuario
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new UsuarioQuery(Db);
            var result = await query.LatestPostsAsync();
            return new OkObjectResult(result);
        }

        // GET api/usuario/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new UsuarioQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/usuario
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] Usuario body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/usuario/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutOne(int id, [FromBody] Usuario body)
        {
            await Db.Connection.OpenAsync();
            var query = new UsuarioQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Login = body.Login;
            result.Senha = body.Senha;
            result.Tipo = body.Tipo;
            result.Nome = body.Nome;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/usuario/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new UsuarioQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/usuario
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new UsuarioQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        //[HttpPost]
        //[Route("login")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login([FromBody] Usuario body)
        //{
        //    await Db.Connection.OpenAsync();
        //    var query = new UsuarioQuery(Db);
        //    var result = await query.LocalizarUsuario(body.Login, body.Senha);
        //    if (result is null)
        //        return new NotFoundResult();
        //    return new OkObjectResult(result);
        //}
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario model)
        {

            await Db.Connection.OpenAsync();
            var query = new UsuarioQuery(Db);

            // Recupera o usuário
            var result = await query.LocalizarUsuario(model.Login, model.Senha);

            // Verifica se o usuário existe
            if (result == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(result);

            result.Token = token;

            // Oculta a senha
            result.Senha = "";

            // Retorna os dados
            return result;
            //return new
            //{
            //    usuario = result,
            //    token = token
            //};
        }

        public AppDb Db { get; }

    }
}
