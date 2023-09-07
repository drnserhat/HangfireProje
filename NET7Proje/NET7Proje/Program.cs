using Hangfire;
using NET7Proje.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices();
var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();
app.UseHangfireDashboard(); // Hangfire arayüzüne eriþim için
app.UseHangfireServer();
// Hangfire görevini zamanlayýn
RecurringJob.AddOrUpdate<DataUpdateService>(x => x.VerileriGuncelleAsync(null), Cron.MinuteInterval(10));
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});
app.Run();
