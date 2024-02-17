

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
            Assert.AreEqual(expected, orderItems.Count);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            Guid id = new OrderItemManager(options).Load().FirstOrDefault().Id;
            Assert.AreEqual(new OrderItemManager(options).LoadById(id).Id, id);
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
            OrderItem orderItem = new OrderItem
            {
                OrderId = new OrderManager(options).Load().FirstOrDefault().Id,
                Quantity = 99,
                MovieId = new MovieManager(options).Load().FirstOrDefault().Id,
                Cost = 20.00
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
            OrderItem orderItem = new OrderItemManager(options).Load().FirstOrDefault();

            Assert.IsTrue(new OrderItemManager(options).Delete(orderItem.Id, true) > 0);
        }
    }
}