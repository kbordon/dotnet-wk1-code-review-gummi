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
        public IActionResult Create(ProductReview thisPR)
        {
            if (thisPR.Review.IsContentCharCountValid())
            {
                thisPR.Review.CheckRating();
				reviewRepo.Save(thisPR.Review);
                return RedirectToAction("Details", "Products", new { id = thisPR.Review.ProductId});
            }
            else
            {
                // do something with text validation? maybe overload details method.
                return RedirectToAction("Details", "Products", new { id = thisPR.Review.ProductId, invalidReview = true });
            }
        }

        //[HttpGet("/Products/{productId}/Reviews")]
        public IActionResult GetAll(int id)
        {
            List<Review> productReviews = reviewRepo.Reviews.Include(r => r.Product).Where(r => r.ProductId == id).OrderByDescending(r => r.Date).ToList();
            return View("Reviews", productReviews);
        }

    }
}
