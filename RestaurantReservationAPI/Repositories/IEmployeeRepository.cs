using RestaurantReservationAPI.Models;

namespace RestaurantReservationAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task AddAsync(Employee entity);
        Task UpdateAsync(Employee entity);
        Task DeleteAsync(Employee entity);
        Task<IEnumerable<Employee>> GetManagersAsync();
        Task<decimal> GetAverageOrderAmountAsync(int employeeId);
    }
}
