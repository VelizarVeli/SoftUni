using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Eventures.Models
{
    public class EventureUser : IdentityUser
    {
        public EventureUser()
        {
            this.Roles = new HashSet<string>();
            this.Reports = new HashSet<Order>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Ucn { get; set; }

        public ICollection<Order> Reports { get; set; }

        [NotMapped]
        public ICollection<string> Roles { get; set; }
    }
}
