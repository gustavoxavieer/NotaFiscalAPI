using Domain.Models;
using Domain.Repositories;
using NotaFiscal.API.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CriarFornecedorAsync(Fornecedor fornecedor)
        {
            await _context.fornecedor.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Fornecedor>> ObterFornecedoresAsync()
        {
            return await _context.fornecedor.ToListAsync();
        }

        public async Task<Fornecedor> ObterFornecedorPorIdAsync(int fornecedorId)
        {
            return await _context.fornecedor.FirstOrDefaultAsync(f => f.Id == fornecedorId);
        }
    }
}
