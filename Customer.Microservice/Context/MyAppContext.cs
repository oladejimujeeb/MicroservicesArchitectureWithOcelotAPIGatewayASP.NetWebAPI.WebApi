using Microsoft.EntityFrameworkCore;
using Customer.Microservice.Entities;
namespace Customer.Microservice.Context
{
    public class MyAppContext:DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext>options):base(options)
        {

        }
        public DbSet<Customers> Customers { get; set; }
    }
}
