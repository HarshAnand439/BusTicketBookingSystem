using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        /*public AppDbContext()
        {
        }*/

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PathRoute> PathRoutes { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
