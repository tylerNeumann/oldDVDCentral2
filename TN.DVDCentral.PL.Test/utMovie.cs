namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie:utBase
    {

        [TestMethod]
        public void LoadTest() 
        {
            Assert.AreEqual(3, dc.tblMovies.Count());
        }

        [TestMethod]
        public void InsertTest() 
        {
            tblMovie entity = new tblMovie();
            entity.Quantity = 1;
            entity.Id = Guid.NewGuid();
            entity.ImagePath = "asdgfhg";
            entity.FormatId = Guid.NewGuid();
            entity.DirectorId = Guid.NewGuid();
            entity.RatingId = Guid.NewGuid();
            entity.Title = "asdf";
            entity.Description = "sfd";
            dc.Add(entity);
            int results =  dc.SaveChanges();
        }

        [TestMethod]
        public void UpdateTest() 
        {
            tblMovie entity = dc.tblMovies.FirstOrDefault();
            entity.Quantity = 99;
            int results = dc.SaveChanges();
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest() 
        {
            tblMovie entity = dc.tblMovies.FirstOrDefault();
            dc.Remove(entity);
            int results = dc.SaveChanges();
            Assert.AreNotEqual(0, results);
        }
    }

}