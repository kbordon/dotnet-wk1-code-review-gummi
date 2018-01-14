using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;
using GummiBearKingdom.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Controllers
{
    public class ReviewsController : Controller
    {
        // instantiate interface
        private IReviewRepository reviewRepo;

        // constructor can be provided test repo or use production one
        public ReviewsController(IReviewRepository repo = null)
        {
            if (repo == null)
            {
                this.reviewRepo = new EFReviewRepository();
            }
            else
            {
                this.reviewRepo = repo;
            }
        }

        // allow several images to be added at some point
        [HttpPost]
        public IActionResult Create(Review review)
        {
            
            reviewRepo.Save(review);
            return RedirectToAction("Details", "Products", new { id = review.ProductId});
        }

        //[HttpGet("/Products/{productId}/Reviews")]
        public IActionResult GetAll(int productId)
        {
            var productReviews = reviewRepo.Reviews.Where(r => r.ProductId == productId).ToList();
            return View("Reviews", productReviews);
        }

    }
}
