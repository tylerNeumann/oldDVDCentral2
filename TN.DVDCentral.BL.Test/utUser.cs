namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utUser : utBase
    {
        [TestInitialize]
        public void Initialize()
        {
            new UserManager(options).Seed();
        }
        [TestMethod]
        public void LoadTest() {
            List<User> users = new UserManager(options).Load();
            Assert.IsTrue(users.Count > 0);
        }
        [TestMethod]
        public void InsertTest()
        {
            User user = new User { FirstName = "Test", LastName = "Test", UserName = "Test", Password = "Test" };
            int result = new UserManager(options).Insert(user, true);
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void LoginSuccessTest()
        {
            User user = new User { FirstName = "Brain", LastName = "Foote", UserName = "bfoote", Password = "maple" };
            bool result = new UserManager(options).Login(user);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LoginFailureNoUserName()
        {
            try
            {
                User user = new User { FirstName = "Brain", LastName = "Foote", UserName = "bfoote", Password = "maple" };
                new UserManager(options).Login(user);
                Assert.Fail();
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
