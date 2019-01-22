using System;

namespace PandaWebApp.Models
{
   public class Receipt
    {
        public int Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.Now;

        public int RecipientId { get; set; }
        public User UserRecipient { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}
