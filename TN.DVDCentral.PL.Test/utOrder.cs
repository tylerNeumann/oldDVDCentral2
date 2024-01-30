namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder : utBase<tblOrder>
    {

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, dc.tblOrders.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblOrder entity = new tblOrder();
            entity.Id = Guid.NewGuid();
            entity.CustomerId = dc.tblCustomers.FirstOrDefault().Id;
            entity.UserId = dc.tblUsers.FirstOrDefault().Id;
            entity.OrderDate = DateTime.Now;
            entity.ShipDate = DateTime.Now;
            dc.Add(entity);
            int results = dc.SaveChanges();
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblOrder entity = dc.tblOrders.FirstOrDefault();
            entity.CustomerId = dc.tblCustomers.FirstOrDefault().Id;
            int results = dc.SaveChanges();
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblOrder entity = dc.tblOrders.FirstOrDefault();
            dc.Remove(entity);
            int results = dc.SaveChanges();
            Assert.AreNotEqual(0, results);
        }
    }

}