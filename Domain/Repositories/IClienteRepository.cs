using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IClienteRepository
    {
        Task CriarClienteAsync(Cliente cliente);
        Task<Cliente> ObterClientePorIdAsync(int id);
        Task<List<Cliente>> ObterClientesAsync();
    }
}
