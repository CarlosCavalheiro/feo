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
    public class AlunoController : ControllerBase
    {
        public AlunoController(AppDb db)
        {
            Db = db;
        }

        // GET api/aluno
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new AlunoQuery(Db);
            var result = await query.LatestPostsAsync();
            return new OkObjectResult(result);
        }

        // GET api/aluno/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new AlunoQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/aluno
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Aluno body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/aluno/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] Aluno body)
        {
            await Db.Connection.OpenAsync();
            var query = new AlunoQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.NomeCompleto = body.NomeCompleto;
            result.Foto = body.Foto;
            result.Modalidade = body.Modalidade;
            result.CEP = body.CEP;
            result.Endereco = body.Estado;
            result.Numero = body.Numero;
            result.Bairro = body.Bairro;
            result.Cidade = body.Cidade;
            result.Estado = body.Estado;
            result.Telefone1 = body.Telefone1;
            result.Telefone2 = body.Telefone2;
            result.ResponsavelId = body.ResponsavelId;
            result.DocenteId = body.DocenteId;
            result.UsuarioId = body.UsuarioId;

            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/aluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new AlunoQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/aluno
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new AlunoQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        public AppDb Db { get; }

    }
}
