using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.TestTools
{
    [TestClass]
    public class ItemTest : IDisposable
    {
        public void Dispose()
        {
            Item.ClearAll();
        }
        [TestMethod]
        public void GetDescription_ReturnDescription_String()
        {
            //Arrange
            string description = "Walk the dog.";
            Item newItem = new Item(description);
            newItem.Save();

            //Act
            List<Item> instances = Item.GetAll();
            Item savedItem = instances[0];
            string result = instances[0].GetDescription();

            //Assert
            Assert.AreEqual(description, result);
        }

        [TestMethod]
        public void SetDescription_SetDescription_String()
        {
            //Arrange
            string description = "Walk the dog.";
            Item newItem = new Item(description);

            //Act
            description = "Do the dishes";
            newItem.SetDescription(description);
            string result = newItem.GetDescription();

            //Assert
            Assert.AreEqual(description, result);
        }

        [TestMethod]
        public void GetAll_ReturnsItems_ItemsList()
        {
            //Arrange
            string description01 = "Walk the dog";
            string description02 = "Do the dishes";
            Item newItem1 = new Item(description01);
            newItem1.Save();
            Item newItem2 = new Item(description02);
            newItem2.Save();
            List<Item> newList = new List<Item> { newItem1, newItem2 };

            //Act
            List<Item> result = Item.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }
    }
}
