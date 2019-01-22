using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_SalesDatabase.Data.Models
{
  public  class Store
    {
        public int StoreId { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string Name { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
