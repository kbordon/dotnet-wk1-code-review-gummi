using System;
using System.IO;
using System.DrawingCore;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.ViewModels
{
    public class ProductImage
    {
        public Product Product { get; set; }
        public Image Render { get; set; }
        
        public ProductImage()
        {
        }

        public ProductImage(Product newProduct)
        {
            Product = newProduct;
            if (newProduct.Image != null)
            {
                MemoryStream ms = new MemoryStream(newProduct.Image);
                Render = Image.FromStream(ms);  
            }
        }
    }
}
