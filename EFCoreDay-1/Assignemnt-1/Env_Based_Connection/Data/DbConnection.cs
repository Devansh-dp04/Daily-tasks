using Microsoft.EntityFrameworkCore;

namespace Env_Based_Connection.Data
{
    public class DbConnection : DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options)
        {

        }
        public DbSet<ClassInfo> ClassInfo { get; set; }
    }
}
