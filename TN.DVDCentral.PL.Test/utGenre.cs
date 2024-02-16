namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre:utBase<tblGenre>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 10;
            var genres = base.LoadTest();
            Assert.AreEqual(expected, genres.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = base.InsertTest(new tblGenre
            {
                Id = Guid.NewGuid(),
                Description = "XXXXXXX"
            });

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblGenre row = base.LoadTest().FirstOrDefault();
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
            tblGenre row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");
            if (row != null)
            {
                int rowsAffected = base.DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
