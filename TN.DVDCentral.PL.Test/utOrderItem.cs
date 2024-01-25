namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrderItem:utBase
    {
        
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, dc.tblOrderItems.Count());
        }

        //[TestMethod]
        //public void InsertTest()
        //{
        //    tblOrderItem entity = new tblOrderItem();
        //    entity.Quantity = 99;
        //    entity.Id = Guid.NewGuid();
        //    entity.OrderId = dc.tblOrders.FirstOrDefault().Id;
        //    entity.MovieId = dc.tblMovies.FirstOrDefault().Id;
        //    entity.Cost = 99;
        //    dc.Add(entity);
        //    int results = dc.SaveChanges();
        //}

        [TestMethod]
        public void UpdateTest()
        {
            tblOrderItem entity = dc.tblOrderItems.FirstOrDefault();
            
            int results = dc.SaveChanges();
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblOrderItem entity = dc.tblOrderItems.FirstOrDefault();
            dc.Remove(entity);
            int results = dc.SaveChanges();
            Assert.AreNotEqual(0, results);
        }
    }

}