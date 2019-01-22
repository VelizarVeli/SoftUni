using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eventures.Models;
using Eventures.Models.ViewModels;

namespace Eventures.Web.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Event, EventViewModel>()
                .ForMember(x => x.EventId,
                           opt => opt.MapFrom(d => d.Id));

            CreateMap<CreateViewModel, Event>();

            CreateMap<Order, MyEventsViewModel>()
                .ForMember(x => x.Name,
                           opt => opt.MapFrom(d => d.Event.Name))
                .ForMember(x => x.Start,
                    opt => opt.MapFrom(d => d.Event.Start.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(x => x.End,
                    opt => opt.MapFrom(d => d.Event.End.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(x => x.Tickets,
                           opt => opt.MapFrom(d => d.TicketsCount));

            CreateMap<Order, AllOrdersViewModel>()
                .ForMember(x => x.EventName,
                    opt => opt.MapFrom(d => d.Event.Name))
                .ForMember(x => x.Customer,
                    opt => opt.MapFrom(c => c.User.UserName))
                .ForMember(x => x.OrderedOn,
                    opt => opt.MapFrom(d => d.OrderedOn.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)));
        }
    }
}
