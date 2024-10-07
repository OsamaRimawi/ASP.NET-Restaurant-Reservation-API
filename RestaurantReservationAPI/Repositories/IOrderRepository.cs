using RestaurantReservationAPI.Models;

namespace RestaurantReservationAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task AddAsync(Order entity);
        Task UpdateAsync(Order entity);
        Task DeleteAsync(Order entity);
    }
}
