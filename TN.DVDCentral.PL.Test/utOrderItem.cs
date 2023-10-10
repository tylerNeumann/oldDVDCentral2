using Microsoft.EntityFrameworkCore.Storage;

namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrderItem
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
            Assert.AreEqual(3, dc.tblOrderItems.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblOrderItem entity = new tblOrderItem();
            entity.Quantity = 99;
            entity.Id = 99;
            entity.OrderId = 99;
            entity.MovieId = 99;
            entity.Cost = 99;
            dc.Add(entity);
            int results = dc.SaveChanges();
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblOrderItem entity = dc.tblOrderItems.FirstOrDefault();
            entity.OrderId = 9999;
            int results = dc.SaveChanges();
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblOrderItem entity = dc.tblOrderItems.Where(e => e.Id == 1).FirstOrDefault();
            dc.Remove(entity);
            int results = dc.SaveChanges();
            Assert.AreNotEqual(0, results);
        }
    }

}