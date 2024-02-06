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
            Assert.AreEqual(expected, formats.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int result = base.InsertTest(new tblFormat
            {
                Id = Guid.NewGuid(),
                Description = "XXXXXXX"
            });

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblFormat row = base.LoadTest().FirstOrDefault();
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
            tblFormat row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");
            if (row != null)
            {
                int result = base.DeleteTest(row);
                Assert.IsTrue(result == 1);
            }
        }
    }
}
//OrderBy(e => e.Id == 1).LastOrDefault()