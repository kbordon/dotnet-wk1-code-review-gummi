using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBearKingdom.Models
{
    [Table("reviews")]
    public class Review
    {

        [Key]
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public string ContentBody { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Rating = 0;

        public override bool Equals(System.Object otherReview)
        {
            if (!(otherReview is Review))
            {
                return false;
            }
            else
            {
                Review newReview = (Review)otherReview;
                return this.ReviewId.Equals(newReview.ReviewId);
            }
        }

        public override int GetHashCode()
        {
            return this.ReviewId.GetHashCode();
        }

        //Call before saving review to database to validate rating.
        public void CheckRating()
        {
            if (Rating > 5)
            {
                Rating = 5;
            }
            else if (Rating < 1)
            {
                Rating = 1;
            }
        }

        //Call before saving review to database to validate number of characters in ContentBody.
        public bool IsContentCharCountValid()
        {
            if (ContentBody.Length > 255)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}