using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NotaFiscal.API.Models
{
    public class NotasFiscal
    {
        [Key]
        [Column("numeronota")]
        public int NumeroNota { get; set; }
        public decimal Valor { get; set; }

        public ClienteDTO Cliente { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
    }

}

