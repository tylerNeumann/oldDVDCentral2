using Microsoft.EntityFrameworkCore.Storage;

namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder
    {
        protected DVDCentralEntities dc;
        protected IDbContextTransaction transaction;
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

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, dc.tblOrders.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblOrder entity = new tblOrder();
            entity.Id = 99;
            entity.CustomerId = 99;
            entity.UserId = 9999;
            entity.OrderDate = DateTime.Now;
            entity.ShipDate = DateTime.Now;
            dc.Add(entity);
            int results = dc.SaveChanges();
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblOrder entity = dc.tblOrders.FirstOrDefault();
            entity.CustomerId = 9999;
            int results = dc.SaveChanges();
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblOrder entity = dc.tblOrders.Where(e => e.Id == 1).FirstOrDefault();
            dc.Remove(entity);
            int results = dc.SaveChanges();
            Assert.AreNotEqual(0, results);
        }
    }

}