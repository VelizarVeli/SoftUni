using System;

namespace TORSHIAWebApp.ViewModels.Tasks
{
   public class CreateTasksInputModel
    {
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public string AffectedSectors { get; set; }
    }
}
