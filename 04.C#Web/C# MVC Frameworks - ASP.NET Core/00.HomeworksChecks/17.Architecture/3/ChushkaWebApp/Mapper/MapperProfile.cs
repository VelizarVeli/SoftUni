namespace EventWebApp.Mapper
{
    using System;
    using System.Globalization;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Models.Account;
    using Models.Events;
    using Models.Orders;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<ApplicationUser, RegisterViewModel>()
                .ForMember(u => u.Username, r => r.MapFrom(m => m.UserName))
                .ReverseMap();

            this.CreateMap<Event, EventViewModel>()
                .ForMember(evm => evm.Order,
                    e => e.MapFrom(s => new OrderViewModel()
                    {
                        EventId = s.Id
                    }))
                .ForMember(evm => evm.Start,
                    e => e.MapFrom(s => s.Start.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(evm => evm.End,
                    e => e.MapFrom(s => s.End.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)))
                .ReverseMap();


            this.CreateMap<IGrouping<Guid,Order>, EventViewModel>()
                .ForMember(evm => evm.Name,
                    e => e.MapFrom(s => s.First().Event.Name))
              .ForMember(o => o.Start,
                    e => e.MapFrom(s => s.First().Event.Start.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(o => o.End,
                    e => e.MapFrom(s => s.First().Event.End.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(o => o.TicketsCount,
                    e => e.MapFrom(s => s.Sum(y=>y.TicketsCount)));

            this.CreateMap<Order, OrderListViewModel>()
                .ForMember(ovm => ovm.Event,
                    e => e.MapFrom(s => s.Event.Name))
                .ForMember(ovm => ovm.Customer,
                    e => e.MapFrom(s => s.Customer.UserName))
                .ForMember(o => o.OrderedOn,
                    e => e.MapFrom(s => s.OrderedOn.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture)));
        }
    }
}
