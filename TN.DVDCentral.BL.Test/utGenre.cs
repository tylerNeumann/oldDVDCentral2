

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utGenre : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 10;
            List<Genre> genres = new GenreManager(options).Load();
            Assert.AreEqual(expected, genres.Count);
        }
        [TestMethod]
        public void InsertTest()
        {
            
            Genre genre = new Genre
            {
                Description = "Test"
            };
            int results = new GenreManager(options).Insert(genre, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Genre genre = new GenreManager(options).Load().FirstOrDefault();
            genre.Description = "Test";
            
            Assert.IsTrue(new GenreManager(options).Update(genre, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Genre genre = new GenreManager(options).Load().FirstOrDefault(x => x.Description == "Other");

            Assert.IsTrue(new GenreManager(options).Delete(genre.Id, true) > 0);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            Genre genre = new GenreManager(options).Load().FirstOrDefault();

            Assert.AreEqual(new GenreManager(options).LoadById(genre.Id).Id, genre.Id);
        }
    }
}