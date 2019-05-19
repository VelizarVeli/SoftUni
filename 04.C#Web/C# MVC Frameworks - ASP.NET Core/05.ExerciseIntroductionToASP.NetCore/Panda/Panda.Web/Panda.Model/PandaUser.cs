using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Panda.Model
{
    public class PandaUser : IdentityUser
    {
        public PandaUser()
        {
            Packages = new HashSet<Package>();
            Receipts = new HashSet<Receipt>();
        }

        public ICollection<Package> Packages { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
    }
}