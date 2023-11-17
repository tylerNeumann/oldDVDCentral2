

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrderItem
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, OrderItemManager.Load().Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            OrderItem orderItem = new OrderItem
            {
                OrderId = 99,
                Quantity = 99,
                MovieId = 99,
                Cost = 20.00f
            };
            int results = OrderItemManager.Insert(orderItem, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            OrderItem orderItem = OrderItemManager.LoadById(2);
            orderItem.Quantity = 9999;
            int results = OrderItemManager.Update(orderItem, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void DeleteTest()
        {
            int id = 0;
            int results = OrderItemManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void LoadByOrderIdTest()
        {
            int orderId = OrderItemManager.Load().FirstOrDefault().OrderId;
            Assert.IsTrue(OrderItemManager.LoadByOrderId(orderId).Count > 0);
        }
    }
}