using Domain.Repositories;
using NotaFiscal.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly ApplicationDbContext _context;

        public NotaFiscalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void CriarNotaFiscal(NotasFiscal notaFiscal)
        {
            _context.notasfiscal.Add(notaFiscal);
            _context.SaveChanges();
        }

        public List<NotasFiscal> ObterNotasFiscais()
        {
            return _context.notasfiscal.ToList();
        }
    }
}
