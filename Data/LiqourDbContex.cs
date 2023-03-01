using LiqourStore.Model;
using Microsoft.EntityFrameworkCore;

namespace LiqourStore.Data
{
    public class LiqourDbContex:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion("8.0.32");
            optionsBuilder.UseMySql("server=localhost;user=root;password=abc123;database=LiqourStore", serverVersion);
        }
        public LiqourDbContex(DbContextOptions<LiqourDbContex> options):
            base(options)
        { }

        public DbSet<Customer>Customers { get; set; }
        public DbSet<Alcohol_Type> AlcoholTypes { get; set;}
        public DbSet<Ordered_Item> OrderedItems { get; set; }
        public DbSet<Order_Details> OrderDetails { get; set; }
        public DbSet<Productcs> Productcs { get; set; }
    }
}
