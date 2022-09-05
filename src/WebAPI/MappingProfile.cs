using AutoMapper;
using Models;
using WebAPI.Models;

namespace WebAPI
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDto, Order>()
                .ReverseMap();

            CreateMap<ClientDto, Client>()
                .ReverseMap();
        }
    }
}
