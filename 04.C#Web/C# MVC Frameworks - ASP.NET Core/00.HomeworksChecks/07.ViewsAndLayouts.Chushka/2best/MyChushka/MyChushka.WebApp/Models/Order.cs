using System;

namespace MyChushka.WebApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string ClientId { get; set; }

        public virtual AppUser Client { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}