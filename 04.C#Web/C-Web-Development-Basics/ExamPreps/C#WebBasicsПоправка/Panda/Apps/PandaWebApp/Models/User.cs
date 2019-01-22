using System.Collections.Generic;

namespace PandaWebApp.Models
{
    public class User
    {
        public User()
        {
            this.Packages = new List<Package>();
            this.Receipts = new List<Receipt>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public ICollection<Receipt> Receipts { get; set; }

        public ICollection<Package> Packages { get; set; }
    }
}
