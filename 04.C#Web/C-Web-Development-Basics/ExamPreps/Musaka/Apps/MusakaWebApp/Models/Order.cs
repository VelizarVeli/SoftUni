using System.ComponentModel.DataAnnotations;

namespace MusakaWebApp.Models
{
  public  class Order
    {
        [Key]
        public int Id { get; set; }

        public Status Status { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public int CashierId { get; set; }
        public virtual User Cashier { get; set; }
    }
}
