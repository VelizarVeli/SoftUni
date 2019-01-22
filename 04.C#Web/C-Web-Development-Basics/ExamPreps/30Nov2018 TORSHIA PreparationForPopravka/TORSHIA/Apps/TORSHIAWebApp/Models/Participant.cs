namespace TORSHIAWebApp.Models
{
    public class Participant
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
