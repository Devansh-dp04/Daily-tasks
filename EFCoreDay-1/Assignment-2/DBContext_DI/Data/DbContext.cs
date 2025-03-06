using Microsoft.EntityFrameworkCore;

namespace DBContext_DI.Data
{
    public class DbConnect : DbContext
    {
        public DbConnect(DbContextOptions<DbConnect> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
