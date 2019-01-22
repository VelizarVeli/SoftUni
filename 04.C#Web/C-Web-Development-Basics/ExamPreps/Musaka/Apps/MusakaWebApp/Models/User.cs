using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusakaWebApp.Models
{
    public class User
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
