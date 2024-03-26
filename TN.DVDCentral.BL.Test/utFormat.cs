
using TN.Reporting;

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utFormat : utBase
    {
        [TestMethod]
        public void utReportTest()
        {

            var format = new FormatManager(options).Load();
            string[] columns = {"Description" };
            var data = FormatManager.ConvertData<Format>(format, columns);
            Excel.Export("movies.xlsx", data);
        }
        [TestMethod]
        public void LoadTest()
        {
            int expected = 4;
            List<Format> formats = new FormatManager(options).Load();
            Assert.AreEqual(expected, formats.Count);
        }
        [TestMethod]
        public void InsertTest()
        {
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
            Format format = new FormatManager(options).Load().FirstOrDefault();
            format.Description = "Test";

            Assert.IsTrue(new FormatManager(options).Update(format, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Format format = new FormatManager(options).Load().FirstOrDefault(x => x.Description == "Other"); ;

            Assert.IsTrue(new FormatManager(options).Delete(format.Id, true) > 0);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            Format format = new FormatManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new FormatManager(options).LoadById(format.Id).Id, format.Id);
        }
    }
}