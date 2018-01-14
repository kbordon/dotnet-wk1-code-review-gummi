using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Controllers
{
    public class HomeController : Controller
    {
        // instantiate interface
        private IProductRepository productRepo;

        // constructor can be provided test repo or use production one
        public HomeController(IProductRepository repo = null)
        {
            if (repo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = repo;
            }
        }

        public IActionResult Index()
        {
            var topThree = productRepo.Products.Include(p => p.Reviews).ToList();
            topThree = Product.FilterTopThree(topThree);
            return View(topThree);
        }
    }
}
