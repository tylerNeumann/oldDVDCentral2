namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre:utBase
    {
        

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
            entity.Id = Guid.NewGuid();
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
            tblGenre entity = dc.tblGenres.FirstOrDefault();
            dc.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreNotEqual(0, result);
        }
    }
    
}
