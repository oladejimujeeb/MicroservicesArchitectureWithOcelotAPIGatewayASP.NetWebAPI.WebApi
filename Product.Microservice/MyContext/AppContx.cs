using Microsoft.EntityFrameworkCore;
using Product.Microservice.Entity;

namespace Product.Microservice.MyContext
{
    public class AppContx:DbContext
    {
        public AppContx(DbContextOptions<AppContx> options):base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
    }
}
