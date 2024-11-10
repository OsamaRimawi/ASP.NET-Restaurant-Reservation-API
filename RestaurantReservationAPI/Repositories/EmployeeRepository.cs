using Microsoft.EntityFrameworkCore;
using RestaurantReservationAPI.Models;

namespace RestaurantReservationAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RestaurantDbContext _context;

        public EmployeeRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee entity)
        {
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.Include(c => c.Reservations).ThenInclude(c => c.Orders).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.Include(c => c.Reservations).ThenInclude(c => c.Orders).Where(c => c.EmployeeId == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Employee entity)
        {
            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Employee>> GetManagersAsync()
        {
            return await _context.Employees
                                 .Include(c => c.Reservations)
                                 .ThenInclude(c => c.Orders)
                                 .Where(e => e.Role == "Manager")
                                 .ToListAsync();
        }
        public async Task<decimal> GetAverageOrderAmountAsync(int employeeId)
        {
            return await _context.Reservations
                                 .Include(r => r.Orders)
                                 .ThenInclude(o => o.MenuItem)
                                 .Where(r => r.EmployeeId == employeeId)
                                 .SelectMany(r => r.Orders)
                                 .AverageAsync(o => o.MenuItem.Price * o.Quantity);
        }
    }

}
