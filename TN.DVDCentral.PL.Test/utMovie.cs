using Microsoft.EntityFrameworkCore.Storage;

namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie
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
            Assert.AreEqual(3, dc.tblMovies.Count());
        }

        [TestMethod]
        public void InsertTest() 
        {
            tblMovie entity = new tblMovie();
            entity.InStkQty = 1;
            entity.Id = 99;
            entity.ImagePath = "asdgfhg";
            entity.FormatId = 1;
            entity.DirectorId = 1;
            entity.RatingId = 1;
            entity.Title = "asdf";
            entity.Description = "sfd";
            dc.Add(entity);
            int results =  dc.SaveChanges();
        }

        [TestMethod]
        public void UpdateTest() 
        {
            tblMovie entity = dc.tblMovies.FirstOrDefault();
            entity.InStkQty = 99;
            int results = dc.SaveChanges();
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest() 
        {
            tblMovie entity = dc.tblMovies.Where(e => e.Id == 1).FirstOrDefault();
            dc.Remove(entity);
            int results = dc.SaveChanges();
            Assert.AreNotEqual(0, results);
        }
    }

}