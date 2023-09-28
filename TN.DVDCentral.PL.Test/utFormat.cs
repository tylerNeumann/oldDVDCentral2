using Microsoft.EntityFrameworkCore.Storage;
using System.Transactions;

namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utFormat
    {
        protected DVDCentralEntities dc;
        protected IDbContextTransaction transaction;
        [TestInitialize]
        public void Initailize()
        {
            dc= new DVDCentralEntities(); 
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
            Assert.AreEqual(3, dc.tblFormats.Count());
            //void id = 0;
            //void results = 0;
            //Assert.AreEqual(3, results)
        }

        [TestMethod]
        public void InsertTest() 
        { 
            tblFormat entity = new tblFormat();
            entity.Description = "Description";
            entity.Id = 111;
            dc.Add(entity);
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest() 
        {
            tblFormat entity = dc.tblFormats.FirstOrDefault();
            entity.Description = "D";
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeleteTest() 
        { 
            tblFormat entity = dc.tblFormats.Where(e => e.Id == 1).FirstOrDefault();
            dc.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreNotEqual(0, result);
        }
    }

}