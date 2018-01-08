using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;
using Microsoft.AspNetCore.Mvc;

namespace GummiBearKingdom.Controllers
{
    public class ImagesController : Controller
    {
        private GummiBearKingdomDbContext db = new GummiBearKingdomDbContext();

        public ActionResult GetImage(int id)
        {
            var thisImage = db.Products.FirstOrDefault(p => p.ProductId == id).Image;
            return File(thisImage, "image/png");
        }
    }
}
