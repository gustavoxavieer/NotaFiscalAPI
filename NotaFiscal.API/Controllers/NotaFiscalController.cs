using Microsoft.AspNetCore.Mvc;
using NotaFiscal.API.Models;
using NotaFiscal.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Models;

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
        public IActionResult CriarNotaFiscal([FromBody] NotaFiscalDTO notaFiscalDto)
        {
            try
            {
                var clienteExistente = _context.cliente.FirstOrDefault(c => c.Nome == notaFiscalDto.Cliente.Nome);
                if (clienteExistente == null)
                {
                    clienteExistente = new Cliente { Nome = notaFiscalDto.Cliente.Nome };
                    _context.cliente.Add(clienteExistente);
                    _context.SaveChanges();  
                }

                var fornecedorExistente = _context.fornecedor.FirstOrDefault(f => f.Nome == notaFiscalDto.Fornecedor.Nome);
                if (fornecedorExistente == null)
                {
                    fornecedorExistente = new Fornecedor { Nome = notaFiscalDto.Fornecedor.Nome };
                    _context.fornecedor.Add(fornecedorExistente);
                    _context.SaveChanges();  
                }

                var novaNotaFiscal = new NotasFiscal
                {
                    NumeroNota = notaFiscalDto.NumeroNota,
                    Valor = notaFiscalDto.Valor,
                    ClienteId = clienteExistente.Id,  
                    FornecedorId = fornecedorExistente.Id  
                };

                _context.notasfiscal.Add(novaNotaFiscal);
                _context.SaveChanges();

                return Ok("Nota fiscal cadastrada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar a nota fiscal: {ex.Message}");
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
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter notas fiscais: {ex.Message}");
            }
        }

        [HttpGet("Detalhes/{id}")]
        public IActionResult GetDetalhesNotaFiscal(int id)
        {
            var detalhesNotaFiscal = _context.notasfiscal
                .Include(nf => nf.Cliente)
                .Include(nf => nf.Fornecedor)
                .FirstOrDefault(f => f.NumeroNota == id);

            if (detalhesNotaFiscal == null)
            {
                return NotFound("Nota fiscal não encontrada.");
            }

            return Ok(detalhesNotaFiscal);
        }
    }
}
