using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesWebApp.Models
{
    public class User : BaseEntity<string>
    {
        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public string Email { get; set; }
    }
}
