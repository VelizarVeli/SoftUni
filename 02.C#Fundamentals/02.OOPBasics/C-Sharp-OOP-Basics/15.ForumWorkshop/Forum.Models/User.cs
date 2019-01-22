using System.Collections.Generic;

namespace Forum.App
{
    public class User
    {
        public User(int id, string username, string password, ICollection<int> posts)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Posts = posts;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<int> Posts { get; set; }
    }
}
