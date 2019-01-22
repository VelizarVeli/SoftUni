using System;
using System.ComponentModel.DataAnnotations;

namespace ChushkaWebApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ClientId { get; set; }
        public User Client { get; set; }

        public DateTime OrderedOn { get; set; } = DateTime.UtcNow;
    }
}
