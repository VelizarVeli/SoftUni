namespace Eventures.WebApp.ViewModels
{
    using System;

    public class EventOutputModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public string Place { get; set; }

        public int Tickets { get; set; }
    }
}