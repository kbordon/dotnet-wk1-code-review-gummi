using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBearKingdom.Models;
using System.IO;
using System;

namespace GummiBearKingdom.Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void GetName_ReturnsReviewName_String()
        {
            //Arrange
            var review = new Review();

            //Act
            review.Author = "Teddy Roosevelt";


            //Assert
            Assert.AreEqual("Teddy Roosevelt", review.Author);
        }

        //[TestMethod]
        //public void GetDescription_ReturnsDescription_String()
        //{
        //    //Arrange
        //    var review = new review();

        //    //Act
        //    review.Description = "The ultimate accessory, the culmination of all gummi innovation and creativity epitomized in this vibrant, gelatinous headdress.";


        //    //Assert
        //    Assert.AreEqual("The ultimate accessory, the culmination of all gummi innovation and creativity epitomized in this vibrant, gelatinous headdress.", review.Description);
        //}

        //[TestMethod]
        //public void GetCost_ReturnsCost_Decimal()
        //{
        //    //Arrange
        //    var review = new review();

        //    //Act
        //    review.Cost = 9999.99m;


        //    //Assert
        //    Assert.AreEqual(9999.99m, review.Cost);
        //}

        //[TestMethod]
        //public void GetImage_ReturnsImage_Array()
        //{
        //    //Arrange
        //    var review = new review();
        //    byte[] array = File.ReadAllBytes("./../../../ModelTests/sadder.jpg");

        //    //Act
        //    review.Image = array;

        //    //Assert
        //    CollectionAssert.AreEqual(array, review.Image);
        //}

        //[TestMethod]
        //public void CheckCost_ReturnsCostRoundedToTwoPlacesForDisplay_Decimal()
        //{
        //    //Arrange
        //    var review = new review();
        //    review.Cost = 10.999m;

        //    //Act
        //    review.CheckCost();

        //    //Assert
        //    Assert.AreEqual(10.99m, review.Cost);
        //}

        //[TestMethod]
        //public void CheckCost_ReturnsCostAddingTwoPlacesForDisplay_Decimal()
        //{
        //    //Arrange
        //    var review = new review();
        //    review.Cost = 10m;

        //    //Act
        //    review.CheckCost();


        //    //Assert
        //    Assert.AreEqual("10.00", review.Cost.ToString());
        //}

    }
}
