namespace Eventures
{
    using AutoMapper;
    using Eventures.Areas.Event.ViewModels;
    using Eventures.Areas.Events.ViewModels;
    using Eventures.Models;
    using Eventures.ViewModels;

    public class MappingCofinguration : Profile
    {
        public MappingCofinguration()
        {
            this.CreateMap<RegisterViewModel, EventuresUser>();
            this.CreateMap<Event, EventViewModel>().ReverseMap();
            this.CreateMap<Order, EventViewModel>();
            this.CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
