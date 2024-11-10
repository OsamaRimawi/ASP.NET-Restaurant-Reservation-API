using AutoMapper;

namespace RestaurantReservationAPI.Profiles
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<Models.MenuItem, DTOs.MenuItemDto>();
            CreateMap<DTOs.MenuItemDto, Models.MenuItem>();
            CreateMap<Models.MenuItem, DTOs.CreateMenuItemDto>();
            CreateMap<DTOs.CreateMenuItemDto, Models.MenuItem>();
        }
    }
}
