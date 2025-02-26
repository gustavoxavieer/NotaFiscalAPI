using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class NotaFiscalConfiguration : IEntityTypeConfiguration<NotasFiscal>
    {
        public void Configure(EntityTypeBuilder<NotasFiscal> builder)
        {
            builder.HasKey(n => n.NumeroNota);

            builder.Property(n => n.Valor)
                .IsRequired();

            builder.HasOne(n => n.Cliente)
                .WithMany()
                .HasForeignKey(n => n.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(n => n.Fornecedor)
                .WithMany()
                .HasForeignKey(n => n.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }

    internal class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
