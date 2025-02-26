using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NotaFiscal.API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly ApplicationDbContext _context;

        public NotaFiscalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CriarNotaFiscalAsync(NotasFiscal notaFiscal)
        {
            await _context.notasfiscal.AddAsync(notaFiscal);
            await _context.SaveChangesAsync();
        }

        public async Task<List<NotasFiscal>> ObterNotasFiscaisAsync()
        {
            return await _context.notasfiscal.ToListAsync();
        }
    }
}
