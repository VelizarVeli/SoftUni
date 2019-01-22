namespace Torshia.App.Models
{
    using System;
    using System.Collections.Generic;
    using Torshia.App.Models.Enums;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}
