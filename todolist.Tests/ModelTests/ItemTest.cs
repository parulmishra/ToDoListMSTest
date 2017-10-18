using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests
{
    [TestClass]
    public class ItemModelTest
    {
        [TestMethod]
        public void GetDescriptionTest()
        {
            //Arrange
            var item = new Item();
            item.Description = "Learn C#";
            //Act 
            var result = item.Description;
            //Assert
            Assert.AreEqual("Learn C#", result);
        }
    }
}
