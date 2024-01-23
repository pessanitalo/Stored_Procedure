using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stored_Procedure.Context;

namespace Consultas_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly DataContext _context;

        public ProcedureController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/procedurebuscaId")]
        public IActionResult buscaId(int id)
        {
            var clientes = _context.Pessoas.FromSqlRaw($"EXEC BuscaId @ID = {id}");
            return Ok(clientes);
        }

        [HttpGet("/listProcedure")]
        public IActionResult ListaPessoasSQL()
        {
            var clientes = _context.Pessoas.FromSqlRaw($"EXEC p_ListaPessoas").ToList();
            return Ok(clientes);
        }

        [HttpGet("/procedurePesquisaNome")]
        public IActionResult pesquisa(string @Nome)
        {
            var clientes = _context.Pessoas.FromSqlRaw($"EXEC PesquisarPessoaNome3 @Nome = {@Nome}");
            return Ok(clientes);
        }
    }
}
