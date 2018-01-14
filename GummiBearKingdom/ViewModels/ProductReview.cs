using System;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.ViewModels
{
    public class ProductReview
    {
        public Product Product { get; set; }
        public Review Review { get; set; }

        public ProductReview()
        {
            Review = new Review();
        }
    }
}
