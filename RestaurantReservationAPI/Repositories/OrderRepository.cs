using Microsoft.EntityFrameworkCore;
using RestaurantReservationAPI.Models;

namespace RestaurantReservationAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext _context;

        public OrderRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                                 .Include(o => o.Reservation)
                                 .Include(o => o.MenuItem)
                                 .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                                 .Include(o => o.Reservation)
                                 .Include(o => o.MenuItem)
                                 .Where(o => o.OrderId == id)
                                 .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}