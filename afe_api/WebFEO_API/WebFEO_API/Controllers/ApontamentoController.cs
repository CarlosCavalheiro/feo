using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebFEO_API.Models;
using WebFEO_API.Query;
using Microsoft.AspNetCore.Authorization;

namespace WebFEO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApontamentoController : ControllerBase
    {

        public ApontamentoController(AppDb db)
        {
            Db = db;
        }

        // GET api/apontamento
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new ApontamentoQuery(Db);
            var result = await query.LatestPostsAsync();
            return new OkObjectResult(result);
        }

        // GET api/apontamento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new ApontamentoQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/apontamento
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Apontamento body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/apontamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] Apontamento body)
        {
            await Db.Connection.OpenAsync();
            var query = new ApontamentoQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.DataApontamento = body.DataApontamento;
            result.Hora = body.Hora;
            result.Observacao = body.Observacao;
            result.PosicaoGPS = body.PosicaoGPS;
            result.Dispositivo = body.Dispositivo;
            result.UsuarioId = body.UsuarioId;
            result.TipoApontamentoId = body.TipoApontamentoId;            

            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/apontamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new ApontamentoQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/apontamento
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new ApontamentoQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        public AppDb Db { get; }

    }
}
