using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Panda.Model.Enums;

namespace Panda.Model
{
    public class User : IdentityUser
    {
        public User()
        {
            Packages = new HashSet<Package>();
            Receipts = new HashSet<Receipt>();
        }

        public Role Role { get; set; }

        public ICollection<Package> Packages { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
    }
}