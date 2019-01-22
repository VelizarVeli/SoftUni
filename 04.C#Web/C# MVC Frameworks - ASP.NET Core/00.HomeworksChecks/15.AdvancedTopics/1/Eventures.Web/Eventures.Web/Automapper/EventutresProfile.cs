using AutoMapper;
using Eventures.Models;
using Eventures.Web.ViewModels.Events;
using Eventures.Web.ViewModels.Orders;
using Eventures.Web.ViewModels.Users;
using System;
using System.Globalization;

namespace Eventures.Web.Automapper
{
    public class EventutresProfile : Profile
    {
        public EventutresProfile()
        {
            CreateMap<RegisterUserBindingModel, EventuresUser>().ReverseMap();

            CreateMap<CreateEventBindingModel, Event>().ReverseMap();

            CreateMap<Event, EventViewModel>()
                .ForMember(dest => dest.Start,
                                    opt => opt.MapFrom(e => e.Start.ToString(@"dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.End,
                                    opt => opt.MapFrom(e => e.End.ToString(@"dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)));

            CreateMap<Order, MyEventViewModel>()
                 .ForMember(dest => dest.Name,
                                    opt => opt.MapFrom(o => o.Event.Name))
                 .ForMember(dest => dest.Start,
                                    opt => opt.MapFrom(o => o.Event.Start.ToString(@"dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)))
                 .ForMember(dest => dest.End,
                                    opt => opt.MapFrom(o => o.Event.End.ToString(@"dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)))
                 .ForMember(dest => dest.Tickets,
                                    opt => opt.MapFrom(o => o.TicketsCount));

            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.EventName,
                                    opt => opt.MapFrom(o => o.Event.Name))
                .ForMember(dest => dest.CustomerName,
                                    opt => opt.MapFrom(o => o.Customer.UserName))
                .ForMember(dest => dest.OrderedOn,
                                    opt => opt.MapFrom(o => o.OrderedOn.ToString(@"dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)));

            CreateMap<CreateOrderBindingModel, Order>()
                .ForMember(dest => dest.OrderedOn,
                                    opt => opt.MapFrom(src => DateTime.Now));


        }
    }
}
