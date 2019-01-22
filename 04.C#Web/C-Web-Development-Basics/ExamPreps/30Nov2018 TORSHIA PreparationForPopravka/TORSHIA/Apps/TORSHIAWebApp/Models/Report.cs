using System;
using TORSHIAWebApp.Models.Enums;

namespace TORSHIAWebApp.Models
{
   public class Report
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public DateTime ReportedOn { get; set; } = DateTime.UtcNow;

        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int ReporterId { get; set; }
        public User Reporter { get; set; }
    }
}
