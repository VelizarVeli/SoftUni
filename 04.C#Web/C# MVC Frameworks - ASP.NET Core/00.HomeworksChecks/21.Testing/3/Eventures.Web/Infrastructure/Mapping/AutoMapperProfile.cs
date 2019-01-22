using AutoMapper;
using Eventures.Models;
using Eventures.Services.Models.Orders;
using Eventures.Web.Models.Events;

namespace Eventures.Web.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Event, CreateEventsViewModel>();
            CreateMap<Order, AllOrdersViewModel>();
        }
    }
}
