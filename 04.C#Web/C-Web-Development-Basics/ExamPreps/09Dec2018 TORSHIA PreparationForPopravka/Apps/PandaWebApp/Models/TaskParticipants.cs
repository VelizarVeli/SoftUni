namespace TorshiaWebApp.Models
{
    public class TaskParticipants
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        public int ParticipantId { get; set; }
        public virtual User Participant { get; set; }
    }
}
