using Hangfire;
using Microsoft.EntityFrameworkCore;
using NET7Proje.Contexts;
using NET7Proje.Models.LocalModels;

namespace NET7Proje.Services
{
    public class DataUpdateService
    {
        private Timer _timer;
        private readonly int _guncellemeAraligiDakika = 10; // Güncelleme aralığı (dakika cinsinden)
        private readonly RemoteDbContext _db;
        private readonly LocalDbContext _mydb;
        public DataUpdateService(RemoteDbContext db, LocalDbContext mydb)
        {
            _db = db;
            _mydb = mydb;
            RecurringJob.AddOrUpdate(() => VerileriGuncelleAsync(null), Cron.MinuteInterval(_guncellemeAraligiDakika));
        }

        public async Task VerileriGuncelleAsync(object state)
        {

       try
            {
                var uzakVeriler = await _db.RemoteDatas.ToListAsync();
                var localveriler = await _mydb.LocalDatas.ToListAsync();
                if (localveriler.Count != uzakVeriler.Count)
                {
                    foreach (var uzakVeri in uzakVeriler)
                    {
                        var hedefVeri = await _mydb.LocalDatas.FirstOrDefaultAsync(h => h.ID == uzakVeri.ID);
                        if (hedefVeri == null)
                        {
                            LocalData local = new LocalData();
                            local.data1 = uzakVeri.data1;
                            local.data2=uzakVeri.data2;
                            local.CreatedDate = uzakVeri.CreatedDate;
                            local.UpdatedDate = uzakVeri.UpdatedDate;
                            _mydb.LocalDatas.Add(local);
                            Console.WriteLine($"Veriler Eklendi:\n data1={local.data1}\ndata2={local.data2}");

                        }


                    }
                    await _mydb.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }
    }
}
