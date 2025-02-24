using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using NotaFiscal.API.Controllers;


namespace Application
{
    public class NotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly ApplicationDbContext _context;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository,
                                 IClienteRepository clienteRepository,
                                 IFornecedorRepository fornecedorRepository,                                 
                                 ApplicationDbContext context)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _clienteRepository = clienteRepository;
            _fornecedorRepository = fornecedorRepository;
            _context = context;
        }

        public void CriarNotaFiscal(NotasFiscal notaFiscal)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var clienteExistente = _clienteRepository.ObterClientePorId(notaFiscal.Cliente.Id);
                    if (clienteExistente == null)
                    {
                        _clienteRepository.CriarCliente(notaFiscal.Cliente);
                    }

                    var fornecedorExistente = _fornecedorRepository.ObterFornecedorPorId(notaFiscal.Fornecedor.Id);
                    if (fornecedorExistente == null)
                    {
                        _fornecedorRepository.CriarFornecedor(notaFiscal.Fornecedor);
                    }

                    _notaFiscalRepository.CriarNotaFiscal(notaFiscal);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public List<NotasFiscal> ObterNotasFiscais()
        {
            return _notaFiscalRepository.ObterNotasFiscais();
        }
    }
}
