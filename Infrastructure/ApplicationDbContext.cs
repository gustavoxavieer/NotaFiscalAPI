using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace NotaFiscal.API.Controllers
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
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome)
                .IsRequired();

            modelBuilder.Entity<Fornecedor>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Fornecedor>()
                .Property(f => f.Nome)
                .IsRequired();

            modelBuilder.Entity<NotasFiscal>()
                .HasKey(n => n.NumeroNota);

            modelBuilder.Entity<NotasFiscal>()
                .Property(n => n.Valor)
                .IsRequired();

            modelBuilder.Entity<NotasFiscal>()
             .HasOne(n => n.Cliente)
             .WithMany()
             .HasForeignKey(n => n.ClienteId);

            modelBuilder.Entity<NotasFiscal>()
                .HasOne(n => n.Fornecedor)
                .WithMany()
                .HasForeignKey(n => n.FornecedorId);



        }

    }

}