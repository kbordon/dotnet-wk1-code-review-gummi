using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBearKingdom.Models;
using System.IO;
using System;
using System.Collections.Generic;

namespace GummiBearKingdom.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void GetName_ReturnsProductName_String()
        {
            //Arrange
            var product = new Product();

            //Act
            product.Name = "Gummi Bear Crown";


            //Assert
            Assert.AreEqual("Gummi Bear Crown", product.Name);
        }

        [TestMethod]
        public void GetDescription_ReturnsDescription_String()
        {
            //Arrange
            var product = new Product();

            //Act
            product.Description = "The ultimate accessory, the culmination of all gummi innovation and creativity epitomized in this vibrant, gelatinous headdress.";


            //Assert
            Assert.AreEqual("The ultimate accessory, the culmination of all gummi innovation and creativity epitomized in this vibrant, gelatinous headdress.", product.Description);
        }

        [TestMethod]
        public void GetCost_ReturnsCost_Decimal()
        {
            //Arrange
            var product = new Product();

            //Act
            product.Cost = 9999.99m;


            //Assert
            Assert.AreEqual(9999.99m, product.Cost);
        }

        [TestMethod]
        public void GetImage_ReturnsImage_Array()
        {
            //Arrange
            var product = new Product();
            byte[] array = File.ReadAllBytes("./../../../ModelTests/sadder.jpg");

            //Act
            product.Image = array;

            //Assert
            CollectionAssert.AreEqual(array, product.Image);
        }

        [TestMethod]
        public void CheckCost_ReturnsCostRoundedToTwoPlacesForDisplay_Decimal()
        {
            //Arrange
            var product = new Product();
            product.Cost = 10.999m;

            //Act
            product.CheckCost();

            //Assert
            Assert.AreEqual(10.99m, product.Cost);
        }

        [TestMethod]
        public void CheckCost_ReturnsCostAddingTwoPlacesForDisplay_Decimal()
        {
            //Arrange
            var product = new Product();
            product.Cost = 10m;

            //Act
            product.CheckCost();


            //Assert
            Assert.AreEqual("10.00", product.Cost.ToString());
        }

        [TestMethod]
        public void GetRating_ReturnsAverageRatingOfProduct_Double()
        {
            //Arrange
            var product = new Product();
            var review1 = new Review { Rating = 2 };
            var review2 = new Review { Rating = 4 };
            var review3 = new Review { Rating = 5 };
            product.Reviews = new List<Review>{review1, review2, review3};

            //Act
            double result = product.GetRating();

            //Assert
            Assert.AreEqual(3.7, result);

        }

    }
}
