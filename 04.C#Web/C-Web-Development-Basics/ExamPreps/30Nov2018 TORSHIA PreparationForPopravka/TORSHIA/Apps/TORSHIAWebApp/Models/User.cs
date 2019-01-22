using System.Collections.Generic;
using TORSHIAWebApp.Models.Enums;

namespace TORSHIAWebApp.Models
{
    public class User
    {
        public User()
        {
            this.Tasks = new List<Participant>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public ICollection<Participant> Tasks { get; set; }
    }
}
