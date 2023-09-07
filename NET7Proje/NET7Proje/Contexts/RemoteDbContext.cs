using Microsoft.EntityFrameworkCore;
using NET7Proje.Models.RemoteModels;

namespace NET7Proje.Contexts
{
    public class RemoteDbContext:DbContext
    {
        public RemoteDbContext(DbContextOptions<RemoteDbContext> options):base(options) { }

        public DbSet<RemoteData> RemoteDatas { get; set; }
    }
}
