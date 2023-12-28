using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stored_Procedure.Context;

namespace Consultas_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListaPessoas()
        {
            var clientes = _context.Pessoas.ToList();

            return Ok(clientes);
        }

        [HttpGet("/lista")]
        public IActionResult ListaPessoasSQL()
        {
            var clientes = _context.Pessoas.FromSqlRaw($"Select * from pessoas").ToList();
            return Ok(clientes);
        }

        [HttpGet("/lista01")]
        public IActionResult ListaPessoasPorParametro()
        {
            var clientes = _context.Pessoas.FromSqlRaw($"Select Id,Nome, Cpf, EnderecoId,DataNascimento from pessoas").ToList();
            return Ok(clientes);
        }

        [HttpGet("/ConsultaWhere")]
        public IActionResult ConsultaWhere()
        {
            var clientes = _context.Pessoas.FromSqlRaw($"Select * from pessoas where id = 1");
            return Ok(clientes);
        }

        [HttpGet("/ConsultaWherePorParametro")]
        public IActionResult ConsultaWhereParametro(int id)
        {
            var clientes = _context.Pessoas.FromSql($"Select * from pessoas where id = {id}");
            return Ok(clientes);
        }

        [HttpGet("/pesquisarPorNome")]
        public IActionResult pesquisarPorNome(string nome)
        {
            var clientes = _context.Pessoas.FromSql($"Select * from pessoas where Nome = {nome}");
            return Ok(clientes);
        }
    }
}
