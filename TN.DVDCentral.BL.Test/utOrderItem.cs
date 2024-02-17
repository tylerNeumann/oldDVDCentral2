

using TN.DVDCentral.BL.Models;

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrderItem : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            List<OrderItem> orderItems = new OrderItemManager(options).Load();
            Assert.AreEqual(expected, orderItems.Count());
        }
        [TestMethod]
        public void LoadByOrderIdTest()
        {
            Guid orderId = new OrderItemManager(options).Load().FirstOrDefault().OrderId;
            Assert.IsTrue(new OrderItemManager(options).LoadByOrderId(orderId).Count > 0);
        }
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            OrderItem orderItem = new OrderItem
            {
                OrderId = Guid.NewGuid(),
                Quantity = 99,
                MovieId = Guid.NewGuid(),
                Cost = 20.00f
            };
            int results = new OrderItemManager(options).Insert(orderItem, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            OrderItem orderItem = new OrderItemManager(options).Load().FirstOrDefault();
            orderItem.Quantity = 9999;

            Assert.IsTrue(new OrderItemManager(options).Update(orderItem, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            OrderItem orderItem = new OrderItemManager(options).Load().FirstOrDefault(x => x.Description == "Other");

            Assert.IsTrue(new OrderItemManager(options).Delete(orderItem.Id, true) > 0);
        }
    }
}