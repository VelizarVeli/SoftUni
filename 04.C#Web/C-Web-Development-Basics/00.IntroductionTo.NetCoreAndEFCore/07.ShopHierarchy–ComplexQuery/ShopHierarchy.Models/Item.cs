using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopHierarchy.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<ItemOrder> Orders { get; set; } = new List<ItemOrder>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
