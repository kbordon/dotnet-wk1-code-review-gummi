using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBearKingdom.Models;
using System.IO;

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

    }
}