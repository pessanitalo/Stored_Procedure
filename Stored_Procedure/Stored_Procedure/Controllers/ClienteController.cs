using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stored_Procedure.Context;
using System.Linq;

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
            var cliente = _context.Pessoas.FromSql($"Select * from pessoas where id = {id}");
            return Ok(cliente);
        }

        [HttpGet("/pesquisarPorNome")]
        public IActionResult pesquisarPorNome(string nome)
        {
            var cliente = _context.Pessoas.FromSql($"Select * from pessoas where Nome = {nome}");
            return Ok(cliente);
        }

        [HttpGet("/pesquisaNome")]
        public IActionResult pesquisaNome(string nome)
        {
            var cliente = _context.Pessoas.Where(c => c.Nome == nome);
            return Ok(cliente);
        }

        [HttpGet("/contains")]
        public IActionResult contains(string cpf)
        {
            var filtrado = _context.Pessoas.Where(str => str.Cpf.Contains(cpf)).ToList();
            return Ok(filtrado);
        }

        [HttpGet("/intervalo")]
        public IActionResult intervalo(DateTime dataInicio, DateTime dataFim)
        {
            //1987-04-28
            var filtro = _context.Pessoas.FromSql($"Select * from pessoas where DataNascimento BETWEEN {dataInicio} and {dataFim}");
            return Ok(filtro);
        }

        [HttpGet("/intervaloLinq")]
        public IActionResult intervaloLinq(DateTime dataInicio, DateTime dataFim)
        {
            //1987-04-28
            var filtrado = _context.Pessoas.Where(str => str.DataNascimento >= dataInicio && str.DataNascimento <= dataFim).ToList();
            return Ok(filtrado);
        }


    }
}
