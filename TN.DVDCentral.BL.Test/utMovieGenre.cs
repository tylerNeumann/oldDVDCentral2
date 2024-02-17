namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovieGenre : utBase
    {

        [TestMethod]
        public void InsertTest()
        {
            Guid movieId = new MovieManager(options).Load().FirstOrDefault().Id;
            Guid genreId = new GenreManager(options).Load().FirstOrDefault().Id;
            int results = new MovieGenreManager(options).Insert(movieId, genreId, true);
            Assert.IsTrue(results > 0);
        }
        //[TestMethod]
        //public void UpdateTest()
        //{
        //    int id = 0;
        //    MovieGenre movieGenre = MovieGenreManager.LoadById(2);
        //    movieGenre.GenreId = 9999;
        //    int results = MovieGenreManager.Update(movieGenre, true);
        //    Assert.AreEqual(1, results);
        //}
        [TestMethod]
        public void DeleteTest()
        {
            tblMovieGenre row = new MovieGenreManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new MovieGenreManager(options).Delete(row.MovieId, row.GenreId, true) > 0);
        }
    }
}