namespace Torshia.App.Models
{
    using System;
    using Torshia.App.Models.Enums;

    public class Report
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public DateTime ReportedOn => DateTime.UtcNow;

        public int TaskId { get; set; }

        public Task Task { get; set; }

        public int ReporterId { get; set; }

        public User Reporter { get; set; }
    }
}
