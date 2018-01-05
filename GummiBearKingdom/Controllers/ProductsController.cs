using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;
using Microsoft.AspNetCore.Mvc;

namespace GummiBearKingdom.Controllers
{
    public class ProductsController : Controller
    {
        // instatiate database context model
        private GummiBearKingdomDbContext db = new GummiBearKingdomDbContext();

        public IActionResult Index()
        {
            List<Product> model = db.Products.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
