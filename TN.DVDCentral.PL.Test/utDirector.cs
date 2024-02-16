namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector : utBase<tblDirector>
    {
        

        [TestMethod]
        public void LoadTest() 
        {
            int expected = 6;
            var directors = base.LoadTest();
            Assert.AreEqual(expected, directors.Count());
        }

        [TestMethod]
        public void InsertTest() 
        {
            int rowsAffected = InsertTest(new tblDirector
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test"
            });            
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest() 
        {
            tblDirector row = base.LoadTest().FirstOrDefault();
            if(row != null)
            {
                row.FirstName = "Test";
                row.LastName = "Test";
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
            

        }

        [TestMethod]
        public void DeleteTest() 
        {
            tblDirector row = dc.tblDirectors.FirstOrDefault(x => x.LastName == "Other");
            if(row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }

}