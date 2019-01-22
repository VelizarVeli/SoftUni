using System;
using System.Collections.Generic;

namespace TORSHIAWebApp.ViewModels.Tasks
{
    public class TaskViewModel
    {
        public string Title { get; set; }

        public int Level { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public ICollection<string> Participants { get; set; }

        public string ParticipantsAsString => string.Join(", ", this.Participants);

        public int AffectedSector { get; set; }
    }
}
