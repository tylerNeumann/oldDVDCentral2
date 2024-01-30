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
            tblMovie entity = new tblMovie();
            entity.Id = Guid.NewGuid();
            entity.Quantity = 1;            
            entity.ImagePath = "asdgfhg";
            entity.RatingId = base.LoadTest().FirstOrDefault().RatingId;
            entity.FormatId = base.LoadTest().FirstOrDefault().FormatId;
            entity.DirectorId = base.LoadTest().FirstOrDefault().DirectorId;
            entity.Title = "asdf";
            entity.Description = "sfd";
            dc.Add(entity);
            int results =  dc.SaveChanges();
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblMovie row = base.LoadTest().FirstOrDefault();
            if (row != null)
            {
                row.Description = "bla";
                int result = base.UpdateTest(row);
                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void DeleteTest() 
        {
            tblMovie row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");
            if (row != null)
            {
                int result = base.DeleteTest(row);
                Assert.IsTrue(result == 1);
            }

            tblMovie entity = dc.tblMovies.FirstOrDefault();
            dc.Remove(entity);
            int results = dc.SaveChanges();
            Assert.AreNotEqual(0, results);
        }
    }

}