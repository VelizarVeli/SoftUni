namespace Torshia.App.Models
{
    using System.Collections.Generic;
    using Torshia.App.Models.Enums;

    public class Sector
    {
        public int Id { get; set; }

        public SectorType SectorType { get; set; }

        public ICollection<TaskSector> Tasks { get; set; }
    }
}