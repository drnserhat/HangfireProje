using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NET7Proje.Models.LocalModels;

namespace NET7Proje.Contexts
{
    public class LocalDbContext:DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }

        public DbSet<LocalData> LocalDatas { get; set; }

    }
}
