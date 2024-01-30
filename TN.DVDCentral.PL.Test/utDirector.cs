namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector : utBase<tblDirector>
    {
        

        [TestMethod]
        public void LoadTest() 
        {
            Assert.AreEqual(3,dc.tblDirectors.Count());
        }

        [TestMethod]
        public void InsertTest() 
        {
            tblDirector entity = new tblDirector();
            entity.FirstName = "Test";
            entity.LastName = "Test";
            entity.Id = Guid.NewGuid();
            dc.Add(entity);
            int result = dc.SaveChanges();
            Assert.AreEqual(1,result);
        }

        [TestMethod]
        public void UpdateTest() 
        {
            tblDirector entity = dc.tblDirectors.FirstOrDefault();
            entity.FirstName = "Test";
            entity.LastName = "Test";
            int result = dc.SaveChanges();
            Assert.AreEqual(1,result);

        }

        [TestMethod]
        public void DeleteTest() 
        {
            tblDirector entity = dc.tblDirectors.FirstOrDefault();
            dc.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreNotEqual(0, result);
        }
    }

}