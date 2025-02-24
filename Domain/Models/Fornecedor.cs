using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Fornecedor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Key]
        [Column("nome")]
        public string Nome { get; set; }
    }
}
