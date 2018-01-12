using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBearKingdom.Models;

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
    }
}
