namespace EventuresWebApp.Web.ViewModels.Events
{
    using System.Collections.Generic;

    public class AllEventsViewModel
    {
        public IEnumerable<EventViewModel> Events { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => CurrentPage == 1 ? 1 : CurrentPage - 1;

        public int NextPage => CurrentPage == TotalPages ? CurrentPage : CurrentPage + 1;

        public int PageSize { get; set; }

        public string ErrorMessage { get; set; }
    }
}
