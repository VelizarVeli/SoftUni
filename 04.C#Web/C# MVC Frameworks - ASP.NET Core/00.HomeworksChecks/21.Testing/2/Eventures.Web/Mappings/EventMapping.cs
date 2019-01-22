using System;
using System.Globalization;
using AutoMapper;
using Eventures.Models;
using Eventures.Web.Controllers;
using Eventures.Web.Models;

namespace Eventures.Web.Mappings
{
    public class EventMapping : Profile
    {
        public EventMapping()
        {

            CreateMap<CreateEventViewModel, Event>()
                .ForMember(e => e.Place, dest => dest.MapFrom(e => e.Place))
                .ForMember(e => e.PricePerTicket, dest => dest.MapFrom(e => e.PricePerTicket))
                .ForMember(e => e.TotalTickets, dest => dest.MapFrom(e => e.TotalTickets))
                .ForMember(e => e.Name, dest => dest.MapFrom(e => e.Name))
                .ForMember(e => e.End, expression => expression.MapFrom(e => DateTime.Parse(e.End)))
                .ForMember(e => e.Start, expression => expression.MapFrom(e => DateTime.Parse(e.Start)));

            CreateMap<Event, EventViewModel>()
                .ForMember(e => e.Id, dest => dest.MapFrom(e => e.Id))
                .ForMember(e => e.Place, dest => dest.MapFrom(e => e.Place))
                .ForMember(e => e.Name, dest => dest.MapFrom(e => e.Name))
                .ForMember(e => e.Start, dest => dest.MapFrom(e => e.Start.ToString("dd-MMM-yy hh:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(e => e.End, dest => dest.MapFrom(e => e.End.ToString("dd-MMM-yy hh:mm:ss", CultureInfo.InvariantCulture)))
                .ForAllOtherMembers(e => e.MapAtRuntime());

            CreateMap<Order, MyEventViewModel>()
                .ForMember(src => src.Name, dest => dest.MapFrom(e => e.Event.Name))
                .ForMember(src => src.TicketsCount, dest => dest.MapFrom(e => e.TicketsCount))
                .ForMember(src => src.Start,
                    dest => dest.MapFrom(
                        e => e.Event.Start.ToString("dd-MMM-yy hh:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(src => src.End,
                    dest => dest.MapFrom(e =>
                        e.Event.End.ToString("dd-MMM-yy hh:mm:ss", CultureInfo.InvariantCulture)));

            /*
             *  var eventModel = new OrderViewModel
                {
                    CustomerName = @event.Customer.FirstName,
                    EventName = @event.Event.Name,
                    OrderedOn = @event.OrderedOn.ToString("dd-MMM-yy hh:mm:ss", CultureInfo.InvariantCulture)
                };
             */

            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.CustomerName, src => src.MapFrom(e => e.Customer.FirstName))
                .ForMember(dest => dest.OrderedOn,
                    src => src.MapFrom(e => e.OrderedOn.ToString("dd-MMM-yy hh:mm:ss", CultureInfo.InvariantCulture)));

            CreateMap<EventureUser, UserViewModel>()
                .ForMember(e => e.Id, x => x.MapFrom(d => d.Id))
                .ForMember(e => e.Username, x => x.MapFrom(d => d.UserName));
            /* var order = new Order
            {
                CustomerId = customerId,
                Customer = customer,
                EventId = bindingModel.EventId,
                TicketsCount = bindingModel.TicketsCount,
                Event = @event
            };
            */

            CreateMap<CreateOrderViewModel, Order>()
                .ForMember(e => e.Id, d => d.Ignore())
                .ForMember(e => e.TicketsCount, d => d.MapFrom(p => p.TotalTickets))
                .ForMember(e => e.OrderedOn, s => s.Ignore())
                .ForMember(e => e.Event, s => s.MapFrom(d => d.Event))
                .ForMember(e => e.Customer, s => s.MapFrom(d => d.Customer))
                .ForMember(e => e.CustomerId, s => s.MapFrom(d => d.CustomerId))
                .ForMember(e => e.EventId, s => s.MapFrom(d => d.EventId))
                .AfterMap((e, d) => { e.Event.TotalTickets -= d.TicketsCount; });


        }
    }
}
 