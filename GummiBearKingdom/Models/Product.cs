using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                return this.ProductId.Equals(newProduct.ProductId);
            }
        }

        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }

        //Run before saving to database to validate cost input.
        public void CheckCost()
        {
            string[] numbersAfterDecimal = Cost.ToString().Split('.');
            if (numbersAfterDecimal.Length > 1)
            {
                if (numbersAfterDecimal[1].Length > 2)
                {
                    numbersAfterDecimal[1] = numbersAfterDecimal[1].Remove(2);
                    string newCostStr = String.Join(".", numbersAfterDecimal);
                    decimal newCost = Convert.ToDecimal(newCostStr);
                    Cost = newCost;
                };  
            }
            else
            {
                string newCostStr = Cost.ToString() + ".00";
                decimal newCost = Convert.ToDecimal(newCostStr);
                Cost = newCost;
            }
        }

        public double GetRating()
        {         
			double avgRating = 0.0;
            if (Reviews.Count > 0)
            {
                foreach(Review review in Reviews)
                {
                    avgRating += review.Rating;
                }
				avgRating = Math.Round(avgRating / Reviews.Count, 1);  
            }
            return avgRating;
        }

        // refactor this or find better implementation for this method.
        //public static List<Product> GetTopThree()
        //{
        //    EFProductRepository proRepo = new EFProductRepository(new TestDbContext());
        //    List<Product> topProducts = new List<Product>();
        //    //var orderedProducts = proRepo.Products.Include(p => p.Reviews).OrderByDescending(p => p.Reviews.Count).ToList();
        //    var orderedProducts = proRepo.Products.Include(p => p.Reviews).ToList().OrderByDescending(p => p.Reviews.Count);
        //    int numTopProducts = 3;
        //    if (orderedProducts.Count() < 3)
        //    {
        //        numTopProducts = orderedProducts.Count();
        //    }
        //    for (int i = 0; i < numTopProducts; i++)
        //    {
        //        topProducts.Add(orderedProducts.ElementAt(i));
        //    }
        //    return topProducts;
        //}

        public static List<Product> FilterTopThree(IEnumerable<Product> thisList)
        {
            List<Product> topProducts = new List<Product>();
            List<Product> orderList = thisList.OrderByDescending(p => p.Reviews.Count).ToList();
            int numTopProducts = 3;
            if (orderList.Count < 3)
            {
                numTopProducts = orderList.Count;
            }
            for (int i = 0; i < numTopProducts; i++)
            {
                topProducts.Add(orderList[i]);
            }
            return topProducts;
        }



    }

}
