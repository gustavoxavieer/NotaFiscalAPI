using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using NotaFiscal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace NotaFiscal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaFiscalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotaFiscalController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("CriarNotaFiscal")]
        public IActionResult CriarNotaFiscal([FromBody] Domain.Models.NotasFiscal notaFiscal)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var clienteExistente = _context.cliente.FirstOrDefault(c => c.Nome == notaFiscal.Cliente.Nome);
                    if (clienteExistente == null)
                    {
                        _context.cliente.Add(notaFiscal.Cliente);
                        _context.SaveChanges();
                    }

                    var fornecedorExistente = _context.fornecedor.FirstOrDefault(f => f.Nome == notaFiscal.Fornecedor.Nome);
                    if (fornecedorExistente == null)
                    {
                        _context.fornecedor.Add(notaFiscal.Fornecedor);
                        _context.SaveChanges();
                    }

                    _context.notasfiscal.Add(notaFiscal);
                    _context.SaveChanges();

                    transaction.Commit();

                    return Ok("Nota fiscal cadastrada com sucesso.");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return StatusCode(500, "Erro ao cadastrar a nota fiscal.");
                }
            }
        }

        [HttpGet]
        public IActionResult ObterNotasFiscais()
        {
            try
            {
                var notasFiscais = _context.notasfiscal
                    .Include(nf => nf.Cliente)
                    .Include(nf => nf.Fornecedor)
                    .ToList();

                return Ok(notasFiscais);

            }
            catch (Exception e)
            {
                var notasFiscais = _context.notasfiscal.ToList();
                return Ok(notasFiscais);
            }

        }

        [HttpGet("Detalhes/{id}")]
        public IActionResult GetDetalhesNotaFiscal(int id)
        {


            var detalhesNotaFiscal = _context.notasfiscal
                .Include(nf => nf.Cliente)
                .Include(nf => nf.Fornecedor)
                .FirstOrDefault(f => f.NumeroNota == id);


            return Ok(detalhesNotaFiscal);
        }

    }
}
