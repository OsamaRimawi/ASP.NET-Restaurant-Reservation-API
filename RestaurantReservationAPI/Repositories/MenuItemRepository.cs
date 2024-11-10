using Microsoft.EntityFrameworkCore;
using RestaurantReservationAPI.Models;

namespace RestaurantReservationAPI.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantDbContext _context;

        public MenuItemRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MenuItem entity)
        {
            await _context.MenuItems.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(MenuItem entity)
        {
            _context.MenuItems.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> GetByIdAsync(int id)
        {
            return await _context.MenuItems.FindAsync(id);
        }

        public async Task UpdateAsync(MenuItem entity)
        {
            _context.MenuItems.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

}
