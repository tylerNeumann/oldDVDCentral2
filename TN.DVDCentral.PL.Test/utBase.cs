

using TN.DVDCentral.PL2.Data;

namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utBase
    {
        protected DVDCentralEntities dc;
        protected IDbContextTransaction transaction;
        private IConfigurationRoot configuration;
        private DbContextOptions<DVDCentralEntities> options;

        public utBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            configuration = builder.Build();
            options = new DbContextOptionsBuilder<DVDCentralEntities>()
                .UseSqlServer(configuration.GetConnectionString("DatabaseConnection"))
                .UseLazyLoadingProxies()
                .Options;

            dc= new DVDCentralEntities(options);
        }

        [TestInitialize]
        public void Initailize()
        {
            dc = new DVDCentralEntities();
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            dc = null;
        }
    }
}
