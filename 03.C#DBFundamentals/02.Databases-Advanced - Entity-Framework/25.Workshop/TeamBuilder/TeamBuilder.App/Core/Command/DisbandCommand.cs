using System;
using System.Linq;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;

namespace TeamBuilder.App.Core.Command
{
    public class DisbandCommand : ICommand
    {
        private readonly TeamBuilderContext _context;
        private readonly AuthenticationManager _authManager;

        public DisbandCommand(AuthenticationManager authManager)
        {
            this._authManager = authManager;
            this._context = new TeamBuilderContext();
        }

        public string Execute(string[] args)
        {
            Check.CheckLength(1, args);
            _authManager.Authorizer();

            var user = _authManager.GetCurrenUser();

            var teamName = args[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(String.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserCreatorOfTeam(teamName, user))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            using (var context = new TeamBuilderContext())
            {
                var team = context.Teams.SingleOrDefault(t => t.Name == teamName);

                var eventTeams = context.TeamEvents.Where(et => et.Team == team);
                var userTeams = context.UserTeams.Where(ut => ut.Team == team);
                var invitations = context.Invitations.Where(i => i.Team == team);

                context.TeamEvents.RemoveRange(eventTeams);
                context.UserTeams.RemoveRange(userTeams);
                context.Invitations.RemoveRange(invitations);

                context.Teams.Remove(team);

                context.SaveChanges();
            }

            return $"{teamName} has disbanded!";
        }
    }
}
