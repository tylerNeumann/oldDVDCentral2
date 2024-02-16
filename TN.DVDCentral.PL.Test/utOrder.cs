namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder : utBase<tblOrder>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var orders = base.LoadTest();
            Assert.AreEqual(expected, orders.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblOrder newRow = new tblOrder();

            newRow.Id = Guid.NewGuid();
            newRow.CustomerId = dc.tblCustomers.FirstOrDefault().Id;
            newRow.UserId = dc.tblUsers.FirstOrDefault().Id;
            newRow.OrderDate = DateTime.Now;
            newRow.ShipDate = DateTime.Now;

            int rowsAffected = InsertTest(newRow);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblOrder row = dc.tblOrders.FirstOrDefault();
            if(row != null)
            {
                row.OrderDate = DateTime.Now;
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
            
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblOrder row = base.LoadTest().FirstOrDefault();
            if (row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.AreNotEqual(0, rowsAffected);
            }
        }
    }

}