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
            var clientes = _context.Pessoas.FromSqlRaw($"EXEC PesquisarPessoaNome @Nome = {@Nome}");
            return Ok(clientes);
        }

        [HttpGet("/oneNumeros")]
        public IActionResult oneNumeros(int @numero)
        {
            var clientes = _context.Enderecos.FromSqlRaw($"EXEC onenumber @numero = {@numero}");
            return Ok(clientes);
        }

        [HttpGet("/intervaloNumeros")]
        public IActionResult intervaloNumeros(int @min, int @max)
        {
            var clientes = _context.Enderecos.FromSqlRaw($"EXEC p_numeros @min = {@min}, @max ={@max}");
            return Ok(clientes);
        }

        [HttpPost("/post")]
        public IActionResult insert(string @Logradouro, string @cep, string @bairro, int @numero, string @mun)
        {
            var clientes = _context.Enderecos.FromSqlRaw($"EXEC intertEndereco1 @Logradouro = {@Logradouro}, @cep ={@cep}, @bairro = {@bairro}, @numero = {@numero}, @mun = {@mun}");
            return Ok(clientes);
        }
    }
}
