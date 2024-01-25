namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovieGenre : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, dc.tblMovieGenres.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblMovieGenre entity = new tblMovieGenre();
            entity.MovieId = Guid.NewGuid();
            entity.Id = Guid.NewGuid();
            entity.GenreId = Guid.NewGuid();
            dc.Add(entity);
            int results = dc.SaveChanges();
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault();
            
            int results = dc.SaveChanges();
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault();
            dc.Remove(entity);
            int results = dc.SaveChanges();
            Assert.AreNotEqual(0, results);
        }
    }

}