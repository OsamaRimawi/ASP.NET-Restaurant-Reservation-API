using AutoMapper;

namespace RestaurantReservationAPI.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Models.Employee, DTOs.EmployeeDto>();
            CreateMap<DTOs.EmployeeDto, Models.Employee>();
            CreateMap<Models.Employee, DTOs.CreateEmployeeDto>();
            CreateMap<DTOs.CreateEmployeeDto, Models.Employee>();
        }
    }
}
