
namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utFormat : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Format> formats = new FormatManager(options).Load();
            Assert.AreEqual(3, formats.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Format format = new Format
            {
                Description = "Test"
            };
            int results = new FormatManager(options).Insert(format, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Format format = new FormatManager(options).Load().FirstOrDefault();
            format.Description = "Test";

            Assert.IsTrue(new FormatManager(options).Update(format, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Format format = new FormatManager(options).Load().FirstOrDefault(); ;

            Assert.IsTrue(new FormatManager(options).Delete(format.Id, true) > 0);
        }
    }
}