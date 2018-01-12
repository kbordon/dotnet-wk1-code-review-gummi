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
        public decimal Rating { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public override bool Equals(System.Object otherReview)
        {
            if(!(otherReview is Review))
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

        public void SetRating(int rating)
        {
            if(rating <= 1 && rating >= 5)
            {
                Rating = rating;
            }
        }
    }
}
