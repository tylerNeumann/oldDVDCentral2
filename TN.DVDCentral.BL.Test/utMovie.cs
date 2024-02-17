

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovie : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Movie> movies = new MovieManager(options).Load();
            Assert.AreEqual(3, movies.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Movie movie = new Movie
            {
                Title = "Test",
                Description = "Test",
                FormatId = new FormatManager(options).Load().FirstOrDefault().Id,
                DirectorId = new DirectorManager(options).Load().FirstOrDefault().Id,
                RatingId = new RatingManager(options).Load().FirstOrDefault().Id,
                Cost = 20.00f,
                Quantity = 10,
                ImagePath = "test"
            };
            int results = new MovieManager(options).Insert(movie, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Movie movie = new MovieManager(options).Load().FirstOrDefault();
            movie.Title = "Test";

            Assert.IsTrue(new MovieManager(options).Update(movie, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Movie movie = new MovieManager(options).Load().FirstOrDefault(x => x.Description == "Other");

            Assert.IsTrue(new MovieManager(options).Delete(movie.Id, true) > 0);
        }
    }
}