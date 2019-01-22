using AutoMapper;
using Eventures.Mapping;
using Eventures.Models;
using System;
using System.Globalization;

namespace Eventures.Services.Models.Orders
{
    public class AllOrdersViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public string EventName { get; set; }

        public string CustomerName { get; set; }

        public DateTime OrderedOn { get; set; }

        public string OrderedOnStr => this.OrderedOn.ToString("dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture);

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Order, AllOrdersViewModel>()
                .ForMember(x => x.CustomerName, x => x.MapFrom(j => j.Customer.FirstName))
                .ForMember(x => x.EventName, x => x.MapFrom(j => j.EventureEvent.Name));
        }
    }
}
