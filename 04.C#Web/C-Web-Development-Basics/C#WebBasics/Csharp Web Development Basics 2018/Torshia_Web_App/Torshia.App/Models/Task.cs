namespace Torshia.App.Models
{
    using System;
    using System.Collections.Generic;

    public class Task
    {
        public Task()
        {
            this.IsReported = false;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; }

        public string Description { get; set; }

        public ICollection<TaskParticitpant> Participants { get; set; }

        public ICollection<TaskSector> AffectedSectors { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}