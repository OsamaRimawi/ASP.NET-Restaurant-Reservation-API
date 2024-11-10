using Microsoft.EntityFrameworkCore;
using RestaurantReservationAPI.Models;

namespace RestaurantReservationAPI.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RestaurantDbContext _context;

        public ReservationRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Reservation entity)
        {
            await _context.Reservations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reservation entity)
        {
            _context.Reservations.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.Include(c => c.Orders).ThenInclude(c => c.MenuItem).ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations.Include(c => c.Orders).ThenInclude(c => c.MenuItem).Where(c => c.ReservationId == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Reservation entity)
        {
            _context.Reservations.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Reservation>> GetByCustomerIdAsync(int customerId)
        {
            return await _context.Reservations
                                 .Include(r => r.Orders)
                                 .ThenInclude(c => c.MenuItem)
                                 .Where(r => r.CustomerId == customerId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItemsByReservationIdAsync(int reservationId)
        {
            return await _context.Orders
                                 .Where(o => o.ReservationId == reservationId)
                                 .Include(o => o.MenuItem)
                                 .Select(o => o.MenuItem)
                                 .ToListAsync();
        }
    }
}
