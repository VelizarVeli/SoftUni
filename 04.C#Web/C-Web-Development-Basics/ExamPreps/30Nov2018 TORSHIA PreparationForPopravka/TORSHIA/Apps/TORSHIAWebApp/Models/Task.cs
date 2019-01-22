using System;
using System.Collections.Generic;

namespace TORSHIAWebApp.Models
{
    public class Task
    {
        public Task()
        {
            this.AffectedSectors = new List<TaskSector>();
            this.Participants = new List<Participant>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; }

        public string Description { get; set; }

        public ICollection<TaskSector> AffectedSectors { get; set; }

        public ICollection<Participant> Participants { get; set; }
    }
}
