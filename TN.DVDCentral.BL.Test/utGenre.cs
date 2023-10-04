using BL.Models;

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utGenre
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(4, GenreManager.Load().Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Genre genre = new Genre
            {
                Description = "Test"
            };
            int results = GenreManager.Insert(genre, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Genre genre = GenreManager.LoadById(2);
            genre.Description = "Test";
            int results = GenreManager.Update(genre, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void DeleteTest()
        {
            int id = 0;
            int results = GenreManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}