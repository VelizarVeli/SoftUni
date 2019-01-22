using System.Collections.Generic;

namespace TorshiaWebApp.Models
{
   public class Participant
    {
        public Participant()
        {
            this.Tasks = new List<TaskParticipants>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TaskParticipants> Tasks{ get; set; }
    }
}
