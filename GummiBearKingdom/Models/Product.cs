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
    }

}
