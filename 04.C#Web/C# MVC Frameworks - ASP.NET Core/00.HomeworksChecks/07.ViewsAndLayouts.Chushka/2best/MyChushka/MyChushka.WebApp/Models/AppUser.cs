using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MyChushka.WebApp.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            this.Orders = new HashSet<Order>();
        }

        public string FullName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}