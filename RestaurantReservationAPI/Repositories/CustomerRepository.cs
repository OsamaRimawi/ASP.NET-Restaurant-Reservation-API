using Microsoft.EntityFrameworkCore;
using RestaurantReservationAPI.Models;

namespace RestaurantReservationAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantDbContext _context;

        public CustomerRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer entity)
        {
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer entity)
        {
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.Include(c => c.Reservations).ThenInclude(c => c.Orders).ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.Include(c => c.Reservations).ThenInclude(c => c.Orders).Where(c => c.CustomerId == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Customer entity)
        {
            _context.Customers.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

}
