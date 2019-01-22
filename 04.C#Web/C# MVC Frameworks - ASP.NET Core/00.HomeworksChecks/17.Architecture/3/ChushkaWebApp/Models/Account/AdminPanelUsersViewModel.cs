namespace EventWebApp.Models.Account
{
    using System.Collections.Generic;

    public class AdminPanelUsersViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public List<string> Role { get; set; } = new List<string>();

        public string RolesAsString => string.Join(", ", this.Role);
    }
}
