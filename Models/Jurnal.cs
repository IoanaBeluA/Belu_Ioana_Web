using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Belu_Ioana_Web.Models
{
    public class Jurnal
    {
        public int ID { get; set; }
        public string Zi { get; set; }
        public string Aliment { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Calorii { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public ICollection<CategorieAliment>? CategorieAlimente{ get; set; }

    }
}
