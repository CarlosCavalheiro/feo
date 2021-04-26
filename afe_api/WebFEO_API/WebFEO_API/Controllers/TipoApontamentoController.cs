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
    public class TipoApontamentoController : ControllerBase
    {

        public TipoApontamentoController(AppDb db)
        {
            Db = db;
        }

        // GET api/tipoapontamento
        [HttpGet]
        public async Task<IActionResult> GetLatest()
        {
            await Db.Connection.OpenAsync();
            var query = new TipoApontamentoQuery(Db);
            var result = await query.LatestPostsAsync();
            return new OkObjectResult(result);
        }

        // GET api/tipoapontamento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new TipoApontamentoQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/tipoapontamento
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoApontamento body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/tipoapontamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] TipoApontamento body)
        {
            await Db.Connection.OpenAsync();
            var query = new TipoApontamentoQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Descricao = body.Descricao;            
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/tipoapontamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new TipoApontamentoQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/tipoapontamento
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new TipoApontamentoQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        public AppDb Db { get; }

    }
}
