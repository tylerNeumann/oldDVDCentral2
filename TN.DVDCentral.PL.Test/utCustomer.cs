

namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer : utBase<tblCustomer>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var customers = base.LoadTest();
            Assert.AreEqual(expected, customers.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblCustomer newRow = new tblCustomer();
            newRow.FirstName = "test";
            newRow.Id = Guid.NewGuid();
            newRow.LastName = "test";
            newRow.UserId = dc.tblUsers.FirstOrDefault().Id;
            newRow.Address = "test";
            newRow.City = "test";
            newRow.State = "Te";
            newRow.ZIP = "test";
            newRow.Phone = "test";
            dc.Add(newRow);
            int rowsAffected = InsertTest(newRow);
            Assert.AreEqual(1,rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblCustomer row = base.LoadTest().FirstOrDefault();
            if(row != null )
            {
                row.FirstName = "test";
                row.LastName = "test";
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
            
            
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblCustomer row = base.LoadTest().FirstOrDefault(x => x.Orders.Count == 0);
            if(row != null )
            {
                int rowsAffected = DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }

}