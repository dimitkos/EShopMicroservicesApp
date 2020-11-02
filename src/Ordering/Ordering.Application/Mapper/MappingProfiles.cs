using AutoMapper;
using Ordering.Application.Commands;
using Ordering.Application.Responses;
using Ordering.Core.Entities;

namespace Ordering.Application.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<CheckoutOrderCommand, Order>();
        }
    }
}
