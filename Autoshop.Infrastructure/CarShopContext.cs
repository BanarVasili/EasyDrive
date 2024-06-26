using System.Data.Entity;
using Autoshop.Domain;

namespace Autoshop.Infrastructure
{
    public class CarShopContext : DbContext
    {
        public CarShopContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }

}