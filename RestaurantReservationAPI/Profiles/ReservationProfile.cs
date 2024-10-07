using AutoMapper;

namespace RestaurantReservationAPI.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Models.Reservation, DTOs.ReservationDto>();
            CreateMap<DTOs.ReservationDto, Models.Reservation>();
            CreateMap<Models.Reservation, DTOs.CreateReservationDto>();
            CreateMap<DTOs.CreateReservationDto, Models.Reservation>();
        }

    }
}
