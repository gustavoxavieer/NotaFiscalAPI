using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories
{
    public interface INotaFiscalRepository
    {
        void CriarNotaFiscal(NotasFiscal notaFiscal);
        List<NotasFiscal> ObterNotasFiscais();
    }
}
