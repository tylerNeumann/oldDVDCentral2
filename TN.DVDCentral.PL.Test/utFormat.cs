namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utFormat : utBase<tblFormat>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 4;
            var formats = base.LoadTest();
            Assert.AreEqual(2, formats[1].tblMovies.Count);
            Assert.AreEqual(expected, formats.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = base.InsertTest(new tblFormat
            {
                Id = Guid.NewGuid(),
                Description = "XXXXXXX"
            });

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblFormat row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");
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
            tblFormat row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");
            if (row != null)
            {
                dc.tblFormats.Remove(row);
                int rowsAffected = dc.SaveChanges();
                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }
}
//OrderBy(e => e.Id == 1).LastOrDefault()