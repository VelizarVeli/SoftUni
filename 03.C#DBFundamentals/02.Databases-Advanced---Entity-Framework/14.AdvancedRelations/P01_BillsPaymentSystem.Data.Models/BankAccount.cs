using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P01_BillsPaymentSystem.Data.Models.Attributes;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }

        public decimal Balance { get; private set; }

        [Required]
        [MaxLength(50)]
        public string BankName { get; set; }

        [Required]
        [MaxLength(20)]
        [NonUnicode]
        [Column("SWIFT Code")]
        public string SwiftCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                this.Balance += amount;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (this.Balance - amount >= 0)
            {
                this.Balance -= amount;
            }
        }
    }
}
