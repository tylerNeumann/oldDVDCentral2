namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie:utBase<tblMovie>
    {

        [TestMethod]
        public void LoadTest() 
        {
            int expected = 7;
            var movies = base.LoadTest();
            Assert.AreEqual(expected, movies.Count());
        }

        [TestMethod]
        public void InsertTest() 
        {
            tblMovie newRow = new tblMovie();

            newRow.Id = Guid.NewGuid();
            newRow.Title = "asdf";
            newRow.Description = "sfd";
            newRow.Cost = 9.99;
            newRow.RatingId = base.LoadTest().FirstOrDefault().RatingId;
            newRow.FormatId = base.LoadTest().FirstOrDefault().FormatId;
            newRow.DirectorId = base.LoadTest().FirstOrDefault().DirectorId;
            newRow.Quantity = 1;            
            newRow.ImagePath = "none";
            
            int rowsAffecteds =  InsertTest(newRow);
            Assert.AreEqual(1, rowsAffecteds);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblMovie row = base.LoadTest().FirstOrDefault();
            if (row != null)
            {
                row.Description = "bla";
                int rowsAffected = base.UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest() 
        {
            tblMovie row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");
            if (row != null)
            {
                int rowsAffected = base.DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }

}