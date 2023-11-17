

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovie
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, MovieManager.Load().Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Movie movie = new Movie
            {
                Title = "Test",
                Description = "Test",
                FormatId = 99,
                DirectorId = 99,
                RatingId = 99,
                Cost = 20.00f,
                InStkQty = 10,
                ImagePath = "test"
            };
            int results = MovieManager.Insert(movie, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Movie movie = MovieManager.LoadById(2);
            movie.Title = "Test";
            int results = MovieManager.Update(movie, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void DeleteTest()
        {
            int id = 0;
            int results = MovieManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}