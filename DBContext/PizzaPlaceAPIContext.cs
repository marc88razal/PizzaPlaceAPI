using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaPlaceAPI.Models;

namespace PizzaPlaceAPI.DBContext
{
    public class PizzaPlaceAPIContext : DbContext
    {
        private readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

        public PizzaPlaceAPIContext()
        {
        }

        public PizzaPlaceAPIContext(string connectionString) : base(GetOptions(connectionString))
        {
        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectStr = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectStr);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<OrderDetails> order_details { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<PizzaTypes> pizza_types { get; set; }
        public DbSet<Pizzas> pizzas { get; set; }
    }
}
