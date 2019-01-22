using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Eventures.Models
{
    public class EventureUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Ucn { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
