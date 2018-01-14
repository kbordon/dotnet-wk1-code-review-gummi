using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GummiBearKingdom.Controllers;
using System.IO;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;
using Moq;
using GummiBearKingdom.ViewModels;

namespace GummiBearKingdom.Tests
{
    [TestClass]
    public class ProductsControllerTests : IDisposable
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();
        EFProductRepository db = new EFProductRepository(new TestDbContext());
        public void Dispose()
        {
            db.DeleteAll();
        }

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
            var model = resultView.ViewData.Model as ProductReview;

            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(ProductReview));
        }

        [TestMethod]
        public void DB_CreatesNewEntries_Collection()
        {
            ProductsController controller = new ProductsController(db);
            Product testProduct = new Product
            {
                Name = "Gummi Couch",
                Description = "Maybe not practical, but definitely possible.",
                Cost = 299.99m
            };

            controller.Create(testProduct, null);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

            CollectionAssert.Contains(collection, testProduct);


        }

        [TestMethod]
        public void DB_DeletesSpecificEntry_Collection()
        {
            ProductsController controller = new ProductsController(db);
            Product testProduct = new Product
                                {
                                    Name = "Gummi Couch",
                                    Description = "Maybe not practical, but definitely possible.",
                                    Cost = 299.99m
                                };
            Product testProduct2 = new Product
                                {
                                    Name = "Gummi Dignity",
                                    Description = "Dignity is hard to preserve sometimes, but when it's gummi maybe it's more resilent and tasty.",
                                    Cost = 19.99m
                                };
            controller.Create(testProduct, null);
            controller.Create(testProduct2, null);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;
            controller.DeleteConfirmed(collection[0].ProductId);
            var collection2 = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

            CollectionAssert.DoesNotContain(collection2, testProduct);
        }

        [TestMethod]
        public void DB_EditSpecificEntry_Product()
        {
            ProductsController controller = new ProductsController(db);
            Product testProduct = new Product
            {
                Name = "Gummi Couch",
                Description = "Maybe not practical, but definitely possible.",
                Cost = 299.99m
            };

            controller.Create(testProduct, null);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;
            Product productToEdit = (controller.Edit(collection[0].ProductId) as ViewResult).ViewData.Model as Product;
            productToEdit.Description = "You'll never lose your change now.";
            controller.Edit(productToEdit);
            var collection2 = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

            Assert.AreNotEqual("Maybe not practical, but definitely possible.", collection2[0].Description);
        }
        

        //This method ended up being used for HomeController instead.
        //first top three test
        //[TestMethod]
        //public void DB_IndexGetsTopThree_List()
        //{
        //    ProductsController controller = new ProductsController(db);
        //    Product testProduct = new Product
        //    {
        //        Name = "Gummi Couch",
        //        Description = "Maybe not practical, but definitely possible.",
        //        Cost = 299.99m
        //    };
        //    controller.Create(testProduct, null);
        //    var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;
        //    foreach(Product product in collection)
        //    {
        //        Console.WriteLine("#################### product name is " + product.Name + " with " + product.Reviews.Count + " reviews."); 
        //    }

        //    Assert.AreEqual(2, collection.Count);

        //}

        //[TestMethod]
        //public void DB_IndexGetsTopThree_List()
        //{
        //    ProductsController controller = new ProductsController(db);
        //    Product testProduct = new Product
        //    {
        //        Name = "Gummi Couch",
        //        Description = "Maybe not practical, but definitely possible.",
        //        Cost = 299.99m
        //    };
        //    controller.Create(testProduct, null);
        //    var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

        //    collection = Product.FilterTopThree(collection);
        //    foreach (Product product in collection)
        //    {
        //        Console.WriteLine("#################### product name is " + product.Name + " with " + product.Reviews.Count + " reviews.");
        //    }

        //    Assert.AreEqual(2, collection.Count);

        //}
    }
}
