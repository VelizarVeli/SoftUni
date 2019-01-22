namespace EventuresWebApp.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class EventuresUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UniqueCitizenNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
