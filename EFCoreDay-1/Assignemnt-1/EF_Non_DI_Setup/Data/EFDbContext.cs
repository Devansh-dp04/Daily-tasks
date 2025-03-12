using EF_Non_DI_Setup.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_Non_DI_Setup.Data
{
    public class EFDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string DbConnString = "Server=LAPTOP-18S4MNJ5\\SQLEXPRESS;Database=EFCoreDemo;User Id=user1;Password=1234;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(DbConnString);
        }
        public DbSet<Teacher> teachers{ get; set; }

    }
}
