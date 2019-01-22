using TORSHIAWebApp.Models.Enums;

namespace TORSHIAWebApp.ViewModels.Reports
{
    public class ReportViewModel
    {
        public string Title { get; set; }

        public int Level { get; set; }

        public Status Status { get; set; }

        //TODO: check if I should do DetailId for the button
    }
}
