using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GummiBearKingdom.Models;
using Moq;
using System.Linq;
using GummiBearKingdom.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GummiBearKingdom.Tests
{
    [TestClass]
    public class ReviewsControllerTests : IDisposable
    {
        Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
        EFReviewRepository db = new EFReviewRepository(new TestDbContext());
        private void DbSetup()
        {
            mock.Setup(m => m.Reviews).Returns(new Review[]
            {
                new Review {
                    ReviewId = 1,
                    Author = "Happy Person",
                    ContentBody = "This is great.",
                    ProductId = 1,
                    Rating = 5
                    },
                new Review {
                    ReviewId = 2,
                    Author = "Neutral Person",
                    ContentBody = "This is ok.",
                    ProductId = 1,
                    Rating = 3
                    },
                new Review {
                    ReviewId = 3,
                    Author = "Unhappy Person",
                    ContentBody = "This is terrible.",
                    ProductId = 2,
                    Rating = 1
                    }
            }.AsQueryable());
        }
        public void Dispose()
        {
            db.DeleteAll();
        }

        [TestMethod]
        public void Mock_PostViewResultCreate_RedirectToActionResult()
        {
            DbSetup();
            Review testReview = new Review
            {
                ReviewId = 4,
                Author = "Satisfied Person",
                ContentBody = "This is pretty good.",
                ProductId = 1,
                Rating = 4
            };
            ReviewsController controller = new ReviewsController(mock.Object);
            var resultRedirect = controller.Create(testReview) as RedirectToActionResult;
            object prodId = new {};
            resultRedirect.RouteValues.TryGetValue("id", out prodId);

            Assert.IsInstanceOfType(resultRedirect, typeof(RedirectToActionResult));
			Assert.AreEqual("Products", resultRedirect.ControllerName);
            Assert.AreEqual(1, prodId);
        }

        [TestMethod]
        public void Mock_GetAllContainsModelData_List()
        {
            DbSetup();
            ViewResult getAllView = new ReviewsController(mock.Object).GetAll(1) as ViewResult;

            var result = getAllView.ViewData.Model;

            Assert.IsInstanceOfType(getAllView, typeof(ViewResult));
            Assert.IsInstanceOfType(result, typeof(List<Review>));
        }
    }
}
