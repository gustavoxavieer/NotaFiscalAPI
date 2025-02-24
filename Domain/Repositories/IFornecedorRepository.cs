using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IFornecedorRepository
    {
        void CriarFornecedor(Fornecedor fornecedor);
        List<Fornecedor> ObterFornecedores();
        Fornecedor ObterFornecedorPorId(int id);
    }
}

