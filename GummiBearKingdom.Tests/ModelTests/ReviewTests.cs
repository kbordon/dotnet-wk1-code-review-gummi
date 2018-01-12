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

        [TestMethod]
        public void GetContentBody_ReturnsContentBody_String()
        {
            //Arrange
            var review = new Review();

            //Act
            review.ContentBody = "My national park is flourishing. My approval rating is up. I'm the president again. My skin is clear.";


            //Assert
            Assert.AreEqual("My national park is flourishing. My approval rating is up. I'm the president again. My skin is clear.", review.ContentBody);
        }

        [TestMethod]
        public void GetRating_ReturnsRating_Int()
        {
            //Arrange
            var review = new Review();

            //Act
            review.Rating = 5;


            //Assert
            Assert.AreEqual(5, review.Rating);
        }

        [TestMethod]
        public void GetProductId_ReturnsProductId_Int()
        {
            //Arrange
            var review = new Review();

            //Act
            review.ProductId = 1;


            //Assert
            Assert.AreEqual(1, review.ProductId);
        }

        [TestMethod]
        public void CheckRating_ReturnsRatingInValidRange_Int()
        {
            //Arrange
            var review = new Review();
            var review2 = new Review();
            review.Rating = 6;
            review2.Rating = -2;

            //Act
            review.CheckRating();
            review2.CheckRating();

            //Assert
            Assert.AreEqual(5, review.Rating);
            Assert.AreEqual(1, review2.Rating);
        }

        [TestMethod]
        public void IsContentCharCountValid_ChecksBodyContentCharacterCountUnder55_False()
        {
            //Arrange
            var review = new Review
            {
                ContentBody = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis,."
            };

            //Act
            bool result = review.IsContentCharCountValid();

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
