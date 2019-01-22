using System;

namespace TorshiaWebApp.ViewModels.Tasks
{
    public class TaskDetailsViewModel
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public DateTime DueDate { get; set; }

        public string Participants { get; set; }

        public string AffectedSectors { get; set; }

        public string Description { get; set; }
    }
}
