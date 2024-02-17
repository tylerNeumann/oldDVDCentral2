

using TN.DVDCentral.BL.Models;

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utRating : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 5;
            List<Rating> ratings = new RatingManager(options).Load();
            Assert.AreEqual(expected, ratings.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
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
            Rating rating = new RatingManager(options).Load().FirstOrDefault();
            rating.Description = "Test";

            Assert.IsTrue(new RatingManager(options).Update(rating, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Rating rating = new RatingManager(options).Load().FirstOrDefault(x => x.Description == "Other");

            Assert.IsTrue(new RatingManager(options).Delete(rating.Id, true) > 0);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            Rating rating = new RatingManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new RatingManager(options).LoadById(rating.Id).Id, rating.Id);
        }
    }
}