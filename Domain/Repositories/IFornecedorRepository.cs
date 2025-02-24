using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IFornecedorRepository
    {
        Task CriarFornecedorAsync(Fornecedor fornecedor);
        Task<List<Fornecedor>> ObterFornecedoresAsync();
        Task<Fornecedor> ObterFornecedorPorIdAsync(int id);
    }
}
