using BL.Models;
using Newtonsoft.Json.Bson;

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrder
    {
        OrderItem orderItems = null;
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, OrderManager.Load().Count());
        }
        //[TestMethod]
        //public void InsertTest()
        //{
        //    int id = 0;
        //    Order order = new Order
        //    {
        //        CustomerId = 99,
        //        OrderDate = DateTime.Now,
        //        UserId = 99,
        //        ShipDate = DateTime.Now
        //    };
        //    int results = OrderManager.Insert(order, orderItems, true);
        //    Assert.AreEqual(1, results);
        //}
        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Order order = OrderManager.LoadById(2);
            order.CustomerId = 9999;
            int results = OrderManager.Update(order, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void DeleteTest()
        {
            int id = 0;
            int results = OrderManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void InsertOrderItemsTest()
        {
            Order order = new Order
            {
                CustomerId = 99,
                OrderDate = DateTime.Now,
                UserId = 99,
                ShipDate = DateTime.Now,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = 88,
                        MovieId = 1,
                        Cost = 9.99f,
                        Quantity= 9
                    },
                    new OrderItem
                    {
                        Id = 99,
                        MovieId = 2,
                        Cost = 8.88f,
                        Quantity= 2
                    }
                }
            };
            
            int result = OrderManager.Insert(order, true);
            Assert.AreEqual(order.OrderItems[1].OrderId, order.Id);
            Assert.AreEqual(3,result);
        }
        [TestMethod]
        public void LoadByIdTest() 
        {
            int id = OrderManager.Load().LastOrDefault().Id;
            Order order = OrderManager.LoadById(id);
            Assert.AreEqual(order.Id, id);
            Assert.IsTrue(order.OrderItems.Count > 0);
        }
    }
}