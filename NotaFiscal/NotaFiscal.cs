using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscal
{
    public class NotaFiscal
    {
        public int NumeroNota { get; set; }
        public decimal Valor { get; set; }
        public Cliente Cliente { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
