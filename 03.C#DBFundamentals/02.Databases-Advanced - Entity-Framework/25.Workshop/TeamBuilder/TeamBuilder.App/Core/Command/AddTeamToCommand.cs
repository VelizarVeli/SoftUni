using System;
using System.Linq;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Command
{
    public class AddTeamToCommand : ICommand
    {
        private readonly TeamBuilderContext _context;
        private readonly AuthenticationManager _authManager;

        public AddTeamToCommand(AuthenticationManager authManager)
        {
            this._authManager = authManager;
            this._context = new TeamBuilderContext();
        }

        public string Execute(string[] args)
        {
            Check.CheckLength(2, args);
            _authManager.Authorizer();

            var user = _authManager.GetCurrenUser();
            string eventName = args[0];
            string teamName = args[1];

            if (!CommandHelper.IsUserCreatorOfEvent(eventName, user))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(String.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(String.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            Event eventa = null;
            Team team = null;

            using (var context = new TeamBuilderContext())
            {
                eventa = context.Events
                    .Where(e => e.Name == eventName)
                    .OrderBy(e => e.StartDate)
                    .Last();

                team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                if (context.TeamEvents.Any(et => et.Team == team && et.Event == eventa))
                {
                    throw new InvalidOperationException("Cannot add same team twice!");
                }

                context.TeamEvents.Add(new TeamEvent() { Event = eventa, Team = team });
                context.SaveChanges();
            }

            return $"Team {teamName} added for {eventName}!";
        }
    }
}
