using Domain.Models;
using Domain.Repositories;
using NotaFiscal.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void CriarCliente(Cliente cliente)
        {
            _context.cliente.Add(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> ObterClientes()
        {
            return _context.cliente.ToList();
        }

        public Cliente ObterClientePorId(int clienteId)
        {
            return _context.cliente.FirstOrDefault(c => c.Id == clienteId);
        }
    }

}
