﻿namespace TN.DVDCentral.BL.Test
{
    [TestClass]
    public class utDirector : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Director> directors = new DirectorManager(options).Load();
            int expected = 6;
            Assert.AreEqual(expected, directors.Count);
        }
        [TestMethod]
        public void InsertTest()
        {
            Director director = new Director
            {
                FirstName = "Test",
                LastName = "Test"
            };
            int result = new DirectorManager(options).Insert(director, true);
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            
            Director director = new DirectorManager(options).Load().FirstOrDefault();
            director.FirstName = "Test";
            
            Assert.IsTrue(new DirectorManager(options).Update(director,true) > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Director director = new DirectorManager(options).Load().FirstOrDefault(x => x.FirstName == "Other");
            Assert.IsTrue(new DirectorManager(options).Delete(director.Id, true) > 0);
        }
        public void LoadByIdTest()
        {
            Director director = new DirectorManager(options).Load().FirstOrDefault(x => x.FirstName == "Other");
            Assert.AreEqual(new DirectorManager(options).LoadById(director.Id).Id, director.Id);
        }
    }
}