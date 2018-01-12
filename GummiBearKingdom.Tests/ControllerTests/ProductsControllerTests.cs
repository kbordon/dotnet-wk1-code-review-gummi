using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GummiBearKingdom.Controllers;
using System.IO;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;
using Moq;

namespace GummiBearKingdom.Tests
{
    [TestClass]
    public class ProductsControllerTests
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
                    Image = null},
                new Product {
                    ProductId = 2,
                    Name = "Gummi Couch",
                    Description = "Maybe not practical, but definitely possible.",
                    Cost = 299.99m,
                    Image = null },
                new Product {
                    ProductId = 1,
                    Name = "Gummi Dignity",
                    Description = "Dignity is hard to preserve sometimes, but when it's gummi maybe it's more resilent and tasty.",
                    Cost = 19.99m,
                    Image = null }
            }.AsQueryable());  
        }

        [TestMethod]
        public void Mock_GetActionResultIndex_ActionResult()
        {
            //Arrange
            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List()
        {
            DbSetup();
            ViewResult indexView = new ProductsController(mock.Object).Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsInstanceOfType(result,typeof(List<Product>));

        }

        [TestMethod]
        public void Mock_IndexModelContainsProducts_Collection()
        {
            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);
            Product testProduct = new Product
            {
                ProductId = 1,
                Name = "Gummi Crown",
                Description = "A Gummi headdress worthy of royalty.",
                Cost = 9999.99m,
                Image = null
            };

            ViewResult indexView = controller.Index() as ViewResult;
            List<Product> collection = indexView.ViewData.Model as List<Product>;

            CollectionAssert.Contains(collection, testProduct);
        }

        [TestMethod]
        public void Mock_PostViewResultCreate_RedirectToActionResult()
        {
            DbSetup();
            Product testProduct = new Product
            {
                ProductId = 1,
                Name = "Gummi Crown",
                Description = "A Gummi headdress worthy of royalty.",
                Cost = 9999.99m,
                Image = null
            };
            ProductsController controller = new ProductsController(mock.Object);

            var resultRedirect = controller.Create(testProduct, null) as RedirectToActionResult;

            Assert.IsInstanceOfType(resultRedirect, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            DbSetup();
            Product testProduct = new Product
            {
                ProductId = 1,
                Name = "Gummi Crown",
                Description = "A Gummi headdress worthy of royalty.",
                Cost = 9999.99m,
                Image = null
            };
            ProductsController controller = new ProductsController(mock.Object);

            var resultView = controller.Details(testProduct.ProductId) as ViewResult;
            var model = resultView.ViewData.Model as Product;

            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Product));
        }
    }
}
