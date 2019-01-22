using AutoMapper;

namespace Eventures.Infrastructure.Contracts
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
