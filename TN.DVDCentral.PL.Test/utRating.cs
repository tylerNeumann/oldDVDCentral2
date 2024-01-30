namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating : utBase<tblRating>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 5;
            var ratings = base.LoadTest();
            Assert.AreEqual(expected, ratings.Count());
        }

        [TestMethod]
        public void InsertTest() 
        {
            int result = base.InsertTest(new tblRating 
                { 
                    Id = Guid.NewGuid(),
                    Description = "XXXXXXX"
                });

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest() 
        {
            tblRating row = base.LoadTest().FirstOrDefault();
            if(row != null)
            {
                row.Description = "bla";
                int result = base.UpdateTest(row);
                Assert.AreEqual(1, result);
            }            
        }

        [TestMethod]
        public void DeleteTest() 
        {
            tblRating row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");
            if(row != null)
            {
                int result = base.DeleteTest(row);
                Assert.IsTrue(result == 1);
            }                       
        }
    }
}