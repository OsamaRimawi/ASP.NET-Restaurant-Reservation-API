using RestaurantReservationAPI.Models;

namespace RestaurantReservationAPI.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation> GetByIdAsync(int id);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task AddAsync(Reservation entity);
        Task UpdateAsync(Reservation entity);
        Task DeleteAsync(Reservation entity);
        Task<IEnumerable<Reservation>> GetByCustomerIdAsync(int customerId);
        Task<IEnumerable<MenuItem>> GetMenuItemsByReservationIdAsync(int reservationId);
    }
}
