using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Eventures.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Orders = new List<Order>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UniqueCitizenNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
