using System.Collections.Generic;

namespace TorshiaWebApp.Models
{
    public class User
    {
        public User()
        {
            this.Reports = new List<Report>();
            this.Tasks = new List<TaskParticipants>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        public virtual ICollection<TaskParticipants>Tasks { get; set; }
    }
}
