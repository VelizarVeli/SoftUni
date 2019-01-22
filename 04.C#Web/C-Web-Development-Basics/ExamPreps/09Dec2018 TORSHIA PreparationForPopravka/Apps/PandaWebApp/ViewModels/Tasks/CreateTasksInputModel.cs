using System;
using System.Collections.Generic;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.ViewModels.Tasks
{
    public class CreateTasksInputModel
    {
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public ICollection<AffectedSectorViewModel> AffectedSectors { get; set; }
    }
}
