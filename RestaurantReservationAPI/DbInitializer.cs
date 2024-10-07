using Microsoft.EntityFrameworkCore;
using RestaurantReservationAPI.Models;

namespace RestaurantReservationAPI
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RestaurantDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<RestaurantDbContext>>()))
            {
                if (context.Employees.Any() || context.Customers.Any() || context.MenuItems.Any() || context.Reservations.Any() || context.Orders.Any())
                {
                    return;
                }

                var employees = new Employee[]
                {
                    new Employee { Name = "Osama Saed", Role = "Manager", Salary = 50000m },
                    new Employee { Name = "Hakam Ahmad", Role = "Chef", Salary = 45000m },
                    new Employee { Name = "Alaa Sami", Role = "Waiter", Salary = 30000m }
                };
                context.Employees.AddRange(employees);

                var customers = new Customer[]
                {
                    new Customer { Name = "Ali Mohammad", Phone = "123-456-7890" },
                    new Customer { Name = "Hamza Namera", Phone = "234-567-8901" },
                    new Customer { Name = "Sadam Hussien", Phone = "345-678-9012" }
                };
                context.Customers.AddRange(customers);

                var menuItems = new MenuItem[]
                {
                    new MenuItem { Name = "Pasta", Price = 12.99m },
                    new MenuItem { Name = "Pizza", Price = 15.99m },
                    new MenuItem { Name = "Salad", Price = 9.99m }
                };
                context.MenuItems.AddRange(menuItems);

                context.SaveChanges();

                var reservations = new Reservation[]
                {
                    new Reservation { CustomerId = customers[0].CustomerId, EmployeeId = employees[0].EmployeeId, ReservationDate = DateTime.Now.AddDays(5) },
                    new Reservation { CustomerId = customers[0].CustomerId, EmployeeId = employees[1].EmployeeId, ReservationDate = DateTime.Now.AddDays(1) },
                    new Reservation { CustomerId = customers[1].CustomerId, EmployeeId = employees[1].EmployeeId, ReservationDate = DateTime.Now.AddDays(2) },
                    new Reservation { CustomerId = customers[2].CustomerId, EmployeeId = employees[0].EmployeeId, ReservationDate = DateTime.Now.AddDays(3) }
                };
                context.Reservations.AddRange(reservations);

                context.SaveChanges();

                var orders = new Order[]
                {
                    new Order { ReservationId = reservations[0].ReservationId, MenuItemId = menuItems[0].MenuItemId, Quantity = 2 },
                    new Order { ReservationId = reservations[0].ReservationId, MenuItemId = menuItems[1].MenuItemId, Quantity = 1 },
                    new Order { ReservationId = reservations[1].ReservationId, MenuItemId = menuItems[2].MenuItemId, Quantity = 3 },
                    new Order { ReservationId = reservations[1].ReservationId, MenuItemId = menuItems[0].MenuItemId, Quantity = 4 },
                    new Order { ReservationId = reservations[2].ReservationId, MenuItemId = menuItems[1].MenuItemId, Quantity = 3 },
                    new Order { ReservationId = reservations[3].ReservationId, MenuItemId = menuItems[2].MenuItemId, Quantity = 6 },
                    new Order { ReservationId = reservations[3].ReservationId, MenuItemId = menuItems[1].MenuItemId, Quantity = 1 }
                };
                context.Orders.AddRange(orders);

                context.SaveChanges();
            }
        }
    }
}