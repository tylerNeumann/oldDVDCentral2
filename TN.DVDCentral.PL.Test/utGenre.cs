using Microsoft.EntityFrameworkCore.Storage;

namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre
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
            Assert.AreEqual(4, dc.tblGenres.Count());
        }

        [TestMethod]
        public void InsertTest() 
        {
            tblGenre entity = new tblGenre();
            entity.Description = "Description";
            entity.Id = 99;
            dc.tblGenres.Add(entity);
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest() 
        {
            tblGenre entity = dc.tblGenres.FirstOrDefault();
            entity.Description = "Description";
            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest() 
        {
            tblGenre entity = dc.tblGenres.Where(e => e.Id == 4).FirstOrDefault();
            dc.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreNotEqual(0, result);
        }
    }
    
}
