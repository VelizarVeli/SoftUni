using System;
using System.Linq;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Command
{
  public  class AcceptInviteCommand : ICommand
    {
        private readonly TeamBuilderContext _context;
        private readonly AuthenticationManager _authManager;

        public AcceptInviteCommand(AuthenticationManager authManager)
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

            AcceptInvite(teamName, user);

            return $"User {user.Username} joined team {teamName}!";
        }

        private void AcceptInvite(string teamName, User user)
        {
            using (var context = new TeamBuilderContext())
            {
                var team = context.Teams
                    .FirstOrDefault(t => t.Name == teamName);
                var currentInvite = context.Invitations
                    .Where(i => i.TeamId == team.Id && i.InvitedUserId == user.Id);

                context.UserTeams.Add(new UserTeam
                {
                    UserId = user.Id,
                    TeamId = team.Id
                });

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

            if (CommandHelper.IsMemberOfTeam(teamName, user.Username))
            {
                using (var context = new TeamBuilderContext())
                {
                    var invite = context.Invitations
                        .FirstOrDefault(i => i.Team.Name == teamName && i.InvitedUser == user && i.IsActive == true);

                    invite.IsActive = false;
                    context.SaveChanges();
                }

                throw new InvalidOperationException($"You are a member of team {teamName}!");
            }
        }
    }
}
