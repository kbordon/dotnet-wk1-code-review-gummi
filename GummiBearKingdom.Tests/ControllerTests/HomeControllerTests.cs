using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GummiBearKingdom.Controllers;
using System.IO;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;
using Moq;

namespace GummiBearKingdom.Tests.ControllerTests
{
    [TestClass]
    public class HomeControllerTests
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();
        private void DbSetup()
        {
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {
                    ProductId = 1,
                    Name = "Gummi Crown",
                    Description = "A Gummi headdress worthy of royalty.",
                    Cost = 9999.99m,
                    Image = null,
                    Reviews = new List<Review>{new Review()}},
                new Product {
                    ProductId = 2,
                    Name = "Gummi Couch",
                    Description = "Maybe not practical, but definitely possible.",
                    Cost = 299.99m,
                    Image = null,
                    Reviews = new List<Review>{new Review(), new Review(), new Review()}},
                new Product {
                    ProductId = 3,
                    Name = "Gummi Dignity",
                    Description = "Dignity is hard to preserve sometimes, but when it's gummi maybe it's more resilent and tasty.",
                    Cost = 19.99m,
                    Image = null,
                    Reviews = new List<Review>{new Review(), new Review()}}
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_IndexGetsTopThree_List()
        {
            DbSetup();
            HomeController controller = new HomeController(mock.Object);

            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;
            foreach(Product product in collection)
            {
                Console.WriteLine("#################### product name is " + product.Name + " with " + product.Reviews.Count + " reviews."); 
            }

            Assert.AreEqual(2, collection[0].ProductId);
            Assert.AreEqual(3, collection[1].ProductId);
            Assert.AreEqual(1, collection[2].ProductId);

        }
    }
}
