namespace NET7Proje.Services
{
        static class Configuration
        {
            static public string ConnectionStringLocal
            {
                get
                {
                    ConfigurationManager configurationManager = new();
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../NET7Proje/NET7Proje"));
                    configurationManager.AddJsonFile("appsettings.json");
                    return configurationManager.GetConnectionString("LocalMssql");
                }
            }
        static public string ConnectionStringRemote
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../NET7Proje/NET7Proje"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("RemotePostgresql");
            }
        }
    }
}
