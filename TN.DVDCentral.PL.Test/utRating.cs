﻿namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating : utBase<tblRating>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 5;
            var ratings = base.LoadTest();
            var moviecount = ratings[1].tblMovies.Count;
            Assert.IsTrue(moviecount > 0);
            Assert.AreEqual(expected, ratings.Count());
        }

        [TestMethod]
        public void InsertTest() 
        {
            int rowsAffected = base.InsertTest(new tblRating 
                { 
                    Id = Guid.NewGuid(),
                    Description = "XXXXXXX"
                });

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest() 
        {
            tblRating row = base.LoadTest().FirstOrDefault();
            if(row != null)
            {
                row.Description = "bla";
                int rowsAffected = base.UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }            
        }

        [TestMethod]
        public void DeleteTest() 
        {
            tblRating row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if(row != null)
            {
                int rowsAffected = base.DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }                       
        }
    }
}