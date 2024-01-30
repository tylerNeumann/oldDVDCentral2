

namespace TN.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer : utBase<tblUser>
    {

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, dc.tblCustomers.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblCustomer entity = new tblCustomer();
            entity.FirstName = "test";
            entity.Id = Guid.NewGuid();
            entity.LastName = "test";
            entity.UserId = dc.tblUsers.FirstOrDefault().Id;
            entity.Address = "test";
            entity.City = "test";
            entity.State = "Te";
            entity.ZIP = "test";
            entity.Phone = "test";
            dc.Add(entity);
            int results = dc.SaveChanges();
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblCustomer entity = dc.tblCustomers.FirstOrDefault();
            
            int results = dc.SaveChanges();
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            tblCustomer entity = dc.tblCustomers.FirstOrDefault();
            dc.Remove(entity);
            int results = dc.SaveChanges();
            Assert.AreNotEqual(0, results);
        }
    }

}