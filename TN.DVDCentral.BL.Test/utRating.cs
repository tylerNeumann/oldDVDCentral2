

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utRating
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, RatingManager.Load().Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Rating rating = new Rating
            {
                Description = "Test"
            };
            int results = RatingManager.Insert(rating, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Rating rating = RatingManager.LoadById(2);
            rating.Description = "Test";
            int results = RatingManager.Update(rating, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void DeleteTest()
        {
            int id = 0;
            int results = RatingManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}