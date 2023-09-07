using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NET7Proje.Contexts;
using System.ComponentModel;

namespace NET7Proje.Services
{
    public static class StartupService
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddDbContext<LocalDbContext>(options => options.UseSqlServer(Configuration.ConnectionStringLocal));
            services.AddDbContext<RemoteDbContext>(options => options.UseNpgsql(Configuration.ConnectionStringRemote));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddHangfire(configuration => configuration.UseSqlServerStorage(Configuration.ConnectionStringLocal)); // Hangfire için veritabanı bağlantısı

            // Hangfire arayüzünü etkinleştirme (isteğe bağlı)
            services.AddHangfireServer();
        }
    }
}
