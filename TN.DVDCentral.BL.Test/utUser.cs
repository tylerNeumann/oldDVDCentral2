namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utUser : utBase
    {
        [TestMethod]
        public void LoginSuccessfulTest()
        {
            Seed();
            Assert.IsTrue(UserManager.Login(new User
            {
                UserName = "bfoote",
                Password = "maple"
            }));
            Assert.IsTrue(UserManager.Login(new User
            {
                UserName = "tneumann",
                Password = "ginger"
            }));
        }
        public void Seed()
        {
            UserManager.Seed();
        }
        public void InsertTest()
        {

        }
        [TestMethod]
        public void LoginFailureNoUserName()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserName = "", Password = "maple" }));
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
        [TestMethod]
        public void LoginFailureBadPassword()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserName = "bfoote", Password = "Maple" }));
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
        [TestMethod]
        public void LoginFailureBadUserName()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserName = "BFoote", Password = "maple" }));
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
        [TestMethod]
        public void LoginFailureNoPassword()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserName = "bfoote", Password = "" }));
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
