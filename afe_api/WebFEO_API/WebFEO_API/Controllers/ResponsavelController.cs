using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFEO_API.Models;
using WebFEO_API.Query;

namespace WebFEO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsavelController : ControllerBase
    {
        public ResponsavelController(AppDb db)
        {
            Db = db;
        }

        // GET api/responsavel
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new ResponsavelQuery(Db);
            var result = await query.LatestPostsAsync();
            return new OkObjectResult(result);
        }

        // GET api/responsavel/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new ResponsavelQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/responsavel
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Responsavel body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/responsavel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] Responsavel body)
        {
            await Db.Connection.OpenAsync();
            var query = new ResponsavelQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.NomeCompleto = body.NomeCompleto;
            result.Foto = body.Foto;            
            result.CEP = body.CEP;
            result.Endereco = body.Estado;
            result.Numero = body.Numero;
            result.Bairro = body.Bairro;
            result.Estado = body.Estado;
            result.Telefone1 = body.Telefone1;
            result.Telefone2 = body.Telefone2;            
            result.UsuarioId = body.UsuarioId;

            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/responsavel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new ResponsavelQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/responsavel
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new ResponsavelQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        public AppDb Db { get; }

    }
}
