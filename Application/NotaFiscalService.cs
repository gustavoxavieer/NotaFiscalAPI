using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using NotaFiscal.API.Data;


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

            if (notaFiscal == null || notaFiscal.Cliente == null || notaFiscal.Fornecedor == null)
            {
                throw new ArgumentException("Os dados da nota fiscal, cliente ou fornecedor são inválidos.");
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var clienteExistente = _clienteRepository.ObterClientePorIdAsync(notaFiscal.Cliente.Id);
                    if (clienteExistente == null)
                    {
                        _clienteRepository.CriarClienteAsync(notaFiscal.Cliente);
                    }

                    var fornecedorExistente = _fornecedorRepository.ObterFornecedorPorIdAsync(notaFiscal.Fornecedor.Id);
                    if (fornecedorExistente == null)
                    {
                        _fornecedorRepository.CriarFornecedorAsync(notaFiscal.Fornecedor);
                    }

                    _notaFiscalRepository.CriarNotaFiscalAsync(notaFiscal);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<List<NotasFiscal>> ObterNotasFiscaisAsync()
        {
            return await _notaFiscalRepository.ObterNotasFiscaisAsync();
        }
    }
}
