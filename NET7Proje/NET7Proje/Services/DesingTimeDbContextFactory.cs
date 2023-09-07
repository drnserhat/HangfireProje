using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using NET7Proje.Contexts;

namespace NET7Proje.Services
{
    public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<RemoteDbContext>
    {
        public RemoteDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<RemoteDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionStringRemote);
            return new RemoteDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
