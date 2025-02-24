using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class NotasFiscal
    {
        [Key]
        [Column("numeronota")]
        public int NumeroNota { get; set; }

        [Key]
        [Column("valor")]
        public decimal Valor { get; set; }

        [Key]
        [Column("clienteid")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }


        [Key]
        [Column("fornecedorid")]
        public int FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }

}
