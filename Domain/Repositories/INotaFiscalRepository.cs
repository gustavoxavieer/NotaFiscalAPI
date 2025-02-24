using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories
{
    public interface INotaFiscalRepository
    {
        Task CriarNotaFiscalAsync(NotasFiscal notaFiscal);
        Task<List<NotasFiscal>> ObterNotasFiscaisAsync();
    }
}
