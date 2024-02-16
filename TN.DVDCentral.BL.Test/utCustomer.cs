
namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utCustomer : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Customer> customers = new CustomerManager(options).Load();
            Assert.AreEqual(3, customers.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            int id = 0;
            Customer customer = new Customer
            {
                FirstName = "Test",
                LastName = "Test",
                UserId = new UserManager(options).Load().FirstOrDefault().Id,
                Address = "test",
                City = "test",
                State = "Te",
                ZIP = "test",
                Phone = "test"
            };
            int results = new CustomerManager(options).Insert(customer, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void UpdateTest()
        {
            
            Customer customer = new CustomerManager(options).Load().FirstOrDefault();
            customer.Address = "Test123";

            Assert.IsTrue(new CustomerManager(options).Update(customer, true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Customer customer = new CustomerManager(options).Load().FirstOrDefault();

            Assert.IsTrue(new CustomerManager(options).Delete(customer.Id, true) > 0); ;
        }
    }
}