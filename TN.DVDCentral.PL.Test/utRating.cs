namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating :utBase
    {

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, dc.tblRatings.Count());
        }

        [TestMethod]
        public void InsertTest() 
        {
            tblRating entity = new tblRating();
            entity.Description = "description";
            entity.Id = Guid.NewGuid();
            dc.Add(entity);
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest() 
        {
            tblRating entity = dc.tblRatings.FirstOrDefault();
            entity.Description = "bla";
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeleteTest() 
        {
            tblRating entity = dc.tblRatings.FirstOrDefault();
            dc.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }
    }

}