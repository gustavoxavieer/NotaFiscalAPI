using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace NotaFiscal.API.Data // Melhor lugar para um DbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Fornecedor> fornecedor { get; set; }
        public DbSet<NotasFiscal> notasfiscal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
