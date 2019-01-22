using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Utilities
{
    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName) == null ? false : true;
            }
        }

        public static bool IsUserExisting(string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Users.SingleOrDefault(x => x.Username == username) == null ? false : true;
            }
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Invitations.Any(i => i.Team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive);
                // user.ReceivedInvitations.SingleOrDefault(x => x.Team.Name == teamName) == null ? false : true;
            }
        }

        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return user.CreatedUserTeams.SingleOrDefault(x => x.Team.Name == teamName) == null ? false : true;
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return user.CreatedEvents.SingleOrDefault(x => x.Name == eventName) == null ? false : true;
            }
        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return //context.Teams.Single(t => t.Name == teamName).UserTeams.Any(ut => ut.User.Username == username);

                        context.Teams.Find(teamName).Members.Any(x => x.User.Username == username);
            }
        }

        public static bool IsEventExisting(string eventName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Events.Any(x => x.Name == eventName);
            }
        }
    }
}
