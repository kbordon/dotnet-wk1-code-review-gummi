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
    public class ProductsController : Controller
    {
        // instantiate interface
        private IProductRepository productRepo;

        // constructor can be provided test repo or use production one
        public ProductsController(IProductRepository repo = null)
        {
            if(repo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = repo;
            }
        }

        public ActionResult Index()
        {
            //return View(Product.GetTopThree());
            return View(productRepo.Products.Include(p => p.Reviews).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product, IFormFile image)
        {
            byte[] newImage = new byte[0];
            if (image != null)
            {
                using (Stream fileStream = image.OpenReadStream())
                using (MemoryStream ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    newImage = ms.ToArray();
                }
                product.Image = newImage;
            }
            product.CheckCost();
            productRepo.Save(product);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id, bool invalidReview = false)
        {
            Product thisProduct = productRepo.Products.Include(p => p.Reviews).FirstOrDefault(p => p.ProductId == id);
            ProductReview thisPR = new ProductReview();
            thisPR.Product = thisProduct;
            thisPR.Review.ProductId = id;
            if (invalidReview)
            {
                thisPR.ReviewFail = invalidReview;
            }
            thisPR.Product.Reviews = thisPR.Product.Reviews.OrderByDescending(r => r.Date).ToList();
            return View(thisPR); 
        }

        public IActionResult Edit(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(p => p.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            productRepo.Edit(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Product thisProduct = productRepo.Products.FirstOrDefault(p => p.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Product thisProduct = productRepo.Products.FirstOrDefault(p => p.ProductId == id);
            productRepo.Remove(thisProduct);
            return RedirectToAction("Index");
        }

        // Get a product's image
        public ActionResult GetImage(int id)
        {
            var thisImage = productRepo.Products.FirstOrDefault(p => p.ProductId == id).Image;
            return File(thisImage, "image/png");
        }

    }
}
