using System;
using System.Collections.Generic;

namespace TorshiaWebApp.Models
{
    public class Task
    {
        public Task()
        {
            this.Participants = new List<TaskParticipants>();
            this.Reports = new List<Report>();
            this.Sectors = new List<AffectedSector>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; } = false;

        public string Description { get; set; }

        public ICollection<AffectedSector> Sectors { get; set; }

        public virtual ICollection<TaskParticipants> Participants { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
