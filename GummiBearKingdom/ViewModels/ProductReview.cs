using System;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.ViewModels
{
    public class ProductReview
    {
        public Product Product { get; set; }
        public Review Review { get; set; }
        public bool ReviewFail { get; set; } = false;

        public ProductReview()
        {
            Review = new Review();
        }
    }
}
