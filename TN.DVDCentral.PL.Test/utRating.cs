using Microsoft.EntityFrameworkCore.Storage;

namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating
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
            Assert.AreEqual(3, dc.tblRatings.Count());
        }

        [TestMethod]
        public void InsertTest() 
        {
            tblRating entity = new tblRating();
            entity.Description = "description";
            entity.Id = 1111;
            dc.Add(entity);
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest() 
        {
            tblRating entity = dc.tblRatings.FirstOrDefault();
            entity.Description = "bla";
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeleteTest() 
        {
            tblRating entity = dc.tblRatings.Where(e => e.Id == 1).FirstOrDefault();
            dc.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }
    }

}