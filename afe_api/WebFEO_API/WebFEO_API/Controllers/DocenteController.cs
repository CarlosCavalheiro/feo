using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebFEO_API.Models;
using WebFEO_API.Query;

namespace WebFEO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        public DocenteController(AppDb db)
        {
            Db = db;
        }

        // GET api/docente
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new DocenteQuery(Db);
            var result = await query.LatestPostsAsync();
            return new OkObjectResult(result);
        }

        // GET api/docente/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new DocenteQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/docente
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Docente body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/docente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] Docente body)
        {
            await Db.Connection.OpenAsync();
            var query = new DocenteQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.NomeCompleto = body.NomeCompleto;
            result.Foto = body.Foto;            
            result.CEP = body.CEP;
            result.Endereco = body.Endereco;
            result.Numero = body.Numero;
            result.Bairro = body.Bairro;
            result.Cidade = body.Cidade;
            result.Estado = body.Estado;
            result.Telefone1 = body.Telefone1;
            result.Telefone2 = body.Telefone2;            
            result.UsuarioId = body.UsuarioId;

            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/docente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new DocenteQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/docente
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new DocenteQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        public AppDb Db { get; }

    }
}
