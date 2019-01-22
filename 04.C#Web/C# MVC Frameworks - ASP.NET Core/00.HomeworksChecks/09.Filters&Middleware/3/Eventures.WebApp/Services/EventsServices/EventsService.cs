namespace Eventures.WebApp.Services.EventsServices
{
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using Data;
	using EventuresModel;
	using ViewModels.Events;

	public class EventsService:IEventsService
	{
		private EventuresDbContext dbContext;

		public EventsService(EventuresDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IList<EventViewModel> All()
		{
			return this.dbContext.EventuresEvents.Select(e => new EventViewModel
			{
				Name = e.Name,
				Place = e.Place,
				Start = e.Start,
				End = e.End,
			}).ToList();
		}

		public void Create(CreateEventViewModel model)
		{
			var eventureEvent = new EventuresEvent()
			{
				Name = model.Name,
				Place = model.Place,
				Start = model.Start,
				End = model.End,
				TotalTickets = model.TotalTickets,
				TicketPrice = model.PricePerTicket
			};

			this.dbContext.Add(eventureEvent);
			this.dbContext.SaveChanges();
		}
	}
}
