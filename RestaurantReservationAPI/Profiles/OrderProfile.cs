using AutoMapper;

namespace RestaurantReservationAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Models.Order, DTOs.OrderDto>();
            CreateMap<DTOs.OrderDto, Models.Order>();
            CreateMap<Models.Order, DTOs.CreateOrderDto>();
            CreateMap<DTOs.CreateOrderDto, Models.Order>();

        }
    }
}
