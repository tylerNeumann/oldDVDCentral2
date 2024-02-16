

using TN.DVDCentral.BL.Models;

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utRating : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Rating> ratings = new RatingManager(options).Load();
            Assert.AreEqual(3, ratings.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Rating rating = new Rating
            {
                Description = "Test"
            };
            int results = new RatingManager(options).Insert(rating, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Rating rating = new RatingManager(options).Load().FirstOrDefault();
            rating.Description = "Test";

            Assert.IsTrue(new RatingManager(options).Update(rating, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Rating rating = new RatingManager(options).Load().FirstOrDefault();

            Assert.IsTrue(new RatingManager(options).Delete(rating.Id, true) > 0);
        }
    }
}