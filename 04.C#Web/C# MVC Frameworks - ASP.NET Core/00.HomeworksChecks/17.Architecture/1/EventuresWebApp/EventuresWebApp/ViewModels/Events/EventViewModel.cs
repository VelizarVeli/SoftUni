namespace EventuresWebApp.Web.ViewModels.Events
{
    using System.ComponentModel.DataAnnotations;

    public class EventViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Tickets")]
        public int TicketsCount { get; set; }

        public string Start { get; set; }

        public string End { get; set; }
    }
}
