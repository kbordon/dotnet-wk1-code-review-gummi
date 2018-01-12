using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

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

        public void CheckCost()
        {
            string[] numbersAfterDecimal = Cost.ToString().Split('.');
            if (numbersAfterDecimal[1].Length > 2 )
            {
                string newCostStr = Cost.ToString("N2");
                Debug.WriteLine(newCostStr);
                decimal newCost = Convert.ToDecimal(newCostStr);
				Cost = newCost;
            };
        }
    }

}
