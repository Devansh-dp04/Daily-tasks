using Microsoft.EntityFrameworkCore;
using Standard_EFCore_Setup.Model;

namespace Standard_EFCore_Setup.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
