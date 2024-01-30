namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utFormat:utBase<tblFormat>
    {
       
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, dc.tblFormats.Count());
            //void id = 0;
            //void results = 0;
            //Assert.AreEqual(3, results)
        }

        [TestMethod]
        public void InsertTest() 
        { 
            tblFormat entity = new tblFormat();
            entity.Description = "Description";
            entity.Id = Guid.NewGuid();
            dc.Add(entity);
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest() 
        {
            tblFormat entity = dc.tblFormats.FirstOrDefault();
            entity.Description = "D";
            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeleteTest() 
        { 
            tblFormat entity = dc.tblFormats.FirstOrDefault();
            dc.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreNotEqual(0, result);
        }
    }

}
//OrderBy(e => e.Id == 1).LastOrDefault()