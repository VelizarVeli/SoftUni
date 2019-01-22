using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
