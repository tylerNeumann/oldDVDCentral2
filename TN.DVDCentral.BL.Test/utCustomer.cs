using BL.Models;

namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, CustomerManager.Load().Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Customer customer = new Customer
            {
                FirstName = "Test",
                LastName = "Test",
                UserId = 99,
                Address = "test",
                City = "test",
                State = "Te",
                ZIP = "test",
                Phone = "test"
            };
            int results = CustomerManager.Insert(customer, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void UpdateTest()
        {
            int id = 0;
            Customer customer = CustomerManager.LoadById(2);
            customer.Address = "Test123";
            int results = CustomerManager.Update(customer, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void DeleteTest()
        {
            int id = 0;
            int results = CustomerManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}