using System;
using System.Linq;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Command
{
    public class DeclineInviteCommand : ICommand
    {
        private readonly TeamBuilderContext _context;
        private readonly AuthenticationManager _authManager;

        public DeclineInviteCommand(AuthenticationManager authManager)
        {
            this._authManager = authManager;
            this._context = new TeamBuilderContext();
        }

        public string Execute(string[] args)
        {
            Check.CheckLength(1, args);
            _authManager.Authorizer();

            var user = _authManager.GetCurrenUser();
            string teamName = args[0];

            CheckTeamInvite(teamName, user);

            DeclineInvite(teamName, user);

            return $"Invite from {teamName} declined.";
        }

        private void DeclineInvite(string teamName, User user)
        {
            using (var context = new TeamBuilderContext())
            {
                var team = context.Teams
                    .FirstOrDefault(t => t.Name == teamName);
                var currentInvite = context.Invitations
                    .Where(i => i.TeamId == team.Id && i.InvitedUserId == user.Id);

                context.Invitations
                    .FirstOrDefault(i => i.TeamId == team.Id && i.InvitedUserId == user.Id)
                    .IsActive = false;

                context.SaveChanges();
            }
        }

        private void CheckTeamInvite(string teamName, User user)
        {
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsInviteExisting(teamName, user))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound, teamName));
            }
        }
    }
}
