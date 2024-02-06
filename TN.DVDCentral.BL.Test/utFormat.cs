
namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utFormat
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Format> formats = new FormatManager(options).Load();
            Assert.AreEqual(3, FormatManager.Load().Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Format format = new Format
            {
                Description = "Test"
            };
            int results = FormatManager.Insert(format, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Format format = FormatManager.LoadById(2);
            format.Description = "Test";
            int results = FormatManager.Update(format, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void DeleteTest()
        {
            int id = 0;
            int results = FormatManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}