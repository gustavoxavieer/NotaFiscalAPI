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
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CriarFornecedor(Fornecedor fornecedor)
        {
            _context.fornecedor.Add(fornecedor);
            _context.SaveChanges();
        }

        public List<Fornecedor> ObterFornecedores()
        {
            return _context.fornecedor.ToList();
        }

        public Fornecedor ObterFornecedorPorId(int fornecedorId)
        {
            return _context.fornecedor.FirstOrDefault(f => f.Id == fornecedorId);
        }
    }

}
