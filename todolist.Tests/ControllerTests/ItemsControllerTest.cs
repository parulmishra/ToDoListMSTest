using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Controllers;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace ToDoList.Tests                  
{   
    [TestClass]
    public class ItemsControllerTest
    {
        [TestMethod]
        public void GetDescriptionTest()
        {
            //Arrange
            ItemsController controller = new ItemsController();
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Get_ModelList_Index_Test()
        {
			//Arrange
			ViewResult indexView = new ItemsController().Index() as ViewResult;

			//Act
			var result = indexView.ViewData.Model;

			//Assert
			Assert.IsInstanceOfType(result, typeof(List<Item>));
        }
        [TestMethod]
        public void Post_MethodAddsItem_Test()
        {
            //Arrange
            ItemsController controller = new ItemsController();
            Item testItem = new Item();
            testItem.Description = "test item";

            //Act
            controller.Create(testItem);
            ViewResult indexView = new ItemsController().Index() as ViewResult;
            var collection = indexView.ViewData.Model as List<Item>;

            //Assert
            CollectionAssert.Contains(collection,testItem);
        }
    }
}
