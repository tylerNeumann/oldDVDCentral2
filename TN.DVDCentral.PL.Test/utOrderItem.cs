namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrderItem:utBase<tblOrderItem>
    {
        
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var orderItems = base.LoadTest();
            Assert.AreEqual(expected, orderItems.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblOrderItem newRow = new tblOrderItem();

            newRow.Id = Guid.NewGuid();
            newRow.OrderId = dc.tblOrders.FirstOrDefault().Id;
            newRow.MovieId = dc.tblMovies.FirstOrDefault().Id;
            newRow.Quantity = 99;
            newRow.Cost = 99;

            int rowsAffected = InsertTest(newRow);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblOrderItem row = dc.tblOrderItems.FirstOrDefault();
            if(row != null)
            {
                row.MovieId = dc.tblMovies.FirstOrDefault().Id;
                row.Quantity = 100;
                row.Cost = 10.99;

                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblOrderItem row = dc.tblOrderItems.FirstOrDefault();
            if (row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.IsTrue(rowsAffected == 1);
            }
        }
    }

}