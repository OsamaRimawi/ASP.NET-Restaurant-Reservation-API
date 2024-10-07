using RestaurantReservationAPI.Models;

namespace RestaurantReservationAPI.Repositories
{
    public interface IMenuItemRepository
    {
        Task<MenuItem> GetByIdAsync(int id);
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task AddAsync(MenuItem entity);
        Task UpdateAsync(MenuItem entity);
        Task DeleteAsync(MenuItem entity);
    }
}
