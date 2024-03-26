

using TN.Reporting;

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovie : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 7;
            List<Movie> movies = new MovieManager(options).Load();
            Assert.AreEqual(expected, movies.Count);
        }
        [TestMethod]
        public void InsertTest()
        {
            Movie movie = new Movie
            {
                Id = Guid.NewGuid(),
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
            Movie movie = new MovieManager(options).Load().FirstOrDefault();
            movie.Title = "Test";

            Assert.IsTrue(new MovieManager(options).Update(movie, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Movie movie = new MovieManager(options).Load().FirstOrDefault();

            Assert.IsTrue(new MovieManager(options).Delete(movie.Id, true) > 0);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            Movie movie = new MovieManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new MovieManager(options).LoadById(movie.Id).Id, movie.Id);
        }

        [TestMethod] public void utReportTest()
        {

            var movies = new MovieManager(options).Load();
            string[] columns = { "Title", "DirectorFullName", "FormatDescription", "RatingDescription", "Quantity" };
            var data = MovieManager.ConvertData<Movie>(movies,columns);
            Excel.Export("movies.xlsx", data);
        }
    }
}