
//using static TN.DVDCentral.BL.MovieGenreManager;

//namespace TN.DVDCentral.BL.Test
//{
//    [TestClass]
//    public class utMovieGenre
//    {
        
//        [TestMethod]
//        public void InsertTest()
//        {
//            int id = 0;
//            MovieGenre movieGenre = new MovieGenre
//            {
//                MovieId = 99,
//                GenreId = 99
//            };
//            //int results = MovieGenreManager.Insert(movieGenre, true);
//            //Assert.AreEqual(1, results);
//        }
//        [TestMethod]
//        public void UpdateTest()
//        {
//            int id = 0;
//            MovieGenre movieGenre = MovieGenreManager.LoadById(2);
//            movieGenre.GenreId = 9999;
//            int results = MovieGenreManager.Update(movieGenre, true);
//            Assert.AreEqual(1, results);
//        }
//        [TestMethod]
//        public void DeleteTest()
//        {
//            int id = 0;
//            int results = MovieGenreManager.Delete(3, true);
//            Assert.AreEqual(1, results);
//        }
//    }
//}