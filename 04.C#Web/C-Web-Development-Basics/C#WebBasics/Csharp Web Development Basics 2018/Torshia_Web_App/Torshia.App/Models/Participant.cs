namespace Torshia.App.Models
{
    using System.Collections.Generic;

    public class Participant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TaskParticitpant> Tasks { get; set; }
    }
}