using System;
using System.Linq;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;

namespace TeamBuilder.App.Core.Command
{
    public class KickMemberCommand : ICommand
    {
        private readonly TeamBuilderContext _context;
        private readonly AuthenticationManager _authManager;

        public KickMemberCommand(AuthenticationManager authManager)
        {
            this._authManager = authManager;
            this._context = new TeamBuilderContext();
        }

        public string Execute(string[] args)
        {
            Check.CheckLength(2, args);
            _authManager.Authorizer();

            var user = _authManager.GetCurrenUser();
            string teamName = args[0];
            string username = args[1];

            if (!CommandHelper.IsUserCreatorOfTeam(teamName, user))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(String.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserExisting(username))
            {
                throw new ArgumentException(String.Format(Constants.ErrorMessages.UserNotFound, username));
            }

            if (!CommandHelper.IsMemberOfTeam(teamName, username))
            {
                throw new ArgumentException(String.Format(Constants.ErrorMessages.NotPartOfTeam, username, teamName));
            }

            if (user.Username == username)
            {
                throw new InvalidOperationException("Command not allowed. Use DisbandTeam instead.");
            }

            using (var context = new TeamBuilderContext())
            {
                var userToBeKicked = context.Users.SingleOrDefault(u => u.Username == username);
                var team = context.Teams.SingleOrDefault(t => t.Name == teamName);
                var userTeam = context.UserTeams.SingleOrDefault(ut => ut.Team == team && ut.User == userToBeKicked);

                context.UserTeams.Remove(userTeam);
                context.SaveChanges();
            }

            return $"User {username} was kicked from {teamName}!";
        }
    }
}
