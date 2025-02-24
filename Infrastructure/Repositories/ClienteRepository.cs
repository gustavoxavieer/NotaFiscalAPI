using Domain.Models;
using Domain.Repositories;
using NotaFiscal.API.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CriarClienteAsync(Cliente cliente)
        {
            await _context.cliente.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> ObterClientesAsync()
        {
            return await _context.cliente.ToListAsync();
        }

        public async Task<Cliente> ObterClientePorIdAsync(int clienteId)
        {
            return await _context.cliente.FirstOrDefaultAsync(c => c.Id == clienteId);
        }
    }
}
