using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
   public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
