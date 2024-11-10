using Microsoft.EntityFrameworkCore;
using RestaurantReservationAPI.Models;

namespace RestaurantReservationAPI
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

    }
}
