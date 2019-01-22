using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusakaWebApp.Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [MaxLength(12), MinLength(12)]
        public long Barcode { get; set; }

        public string Picture { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
