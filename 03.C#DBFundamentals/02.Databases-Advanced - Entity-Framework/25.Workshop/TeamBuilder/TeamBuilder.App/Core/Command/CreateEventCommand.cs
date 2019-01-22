using System;
using TeamBuilder.App.Utilities;
using System.Globalization;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Command
{
    public class CreateEventCommand : ICommand
    {
        private readonly TeamBuilderContext _context;
        private readonly AuthenticationManager _authManager;

        public CreateEventCommand(AuthenticationManager authManager)
        {
            this._authManager = authManager;
            this._context = new TeamBuilderContext();
        }

        public string Execute(string[] args)
        {
            Check.CheckLength(6, args);
           _authManager.Authorizer();

            User user = this._authManager.GetCurrenUser();

            var eventName = args[0];
            CheckEventName(eventName);

            var eventDescription = args[1];
            CheckEventDescription(eventDescription);

            string fullStartDate = $"{args[2]} {args[3]}";
            DateTime startDate;
            bool isStartDateValid = DateTime
                .TryParseExact(fullStartDate, Constants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);

            string fullEndDate = $"{args[4]} {args[5]}";
            DateTime endDate;
            bool isEndDateValid = DateTime
                .TryParseExact(fullEndDate, Constants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            if (!isStartDateValid || !isEndDateValid)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidDateFormat);
            }

            AddEventToDb(user, eventName, eventDescription, startDate, endDate);

            return $"Event {eventName} was created successfully!";
        }

        private static void AddEventToDb(User user, string eventName, string eventDescription, DateTime startDate, DateTime endDate)
        {
            using (var context = new TeamBuilderContext())
            {
                var newEvent = new Event
                {
                    Name = eventName,
                    Description = eventDescription,
                    StartDate = startDate,
                    EndDate = endDate,
                    CreatorId = user.Id
                };

                context.Events.Add(newEvent);
                context.SaveChanges();
            }
        }

        private void CheckEventName(string eventName)
        {
            if (eventName.Length > Constants.MaxEventNameLength)
            {
                throw new ArgumentException("Event name should be up to 25 characters long!");
            }
        }

        private void CheckEventDescription(string eventDescription)
        {
            if (eventDescription.Length > Constants.MaxEventDescriptionLength)
            {
                throw new ArgumentException("Event description should be up to 250 characters long!");
            }
        }
    }
}
