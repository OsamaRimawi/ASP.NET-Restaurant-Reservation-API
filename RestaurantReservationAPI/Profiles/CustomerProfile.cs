using AutoMapper;

namespace RestaurantReservationAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Models.Customer, DTOs.CustomerDto>();
            CreateMap<DTOs.CustomerDto, Models.Customer>();
            CreateMap<Models.Customer, DTOs.CreateCustomerDto>();
            CreateMap<DTOs.CreateCustomerDto, Models.Customer>();

        }
    }
}
