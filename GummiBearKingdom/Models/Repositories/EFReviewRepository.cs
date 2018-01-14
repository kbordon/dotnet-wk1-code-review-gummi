using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        GummiBearKingdomDbContext db;

        public EFReviewRepository()
        {
            db = new GummiBearKingdomDbContext();
        }

        // for testing purposes.
        public EFReviewRepository(GummiBearKingdomDbContext thisDb)
        {
            db = thisDb;
        }

        // get all reviews
        public IQueryable<Review> Reviews
        {
            get { return db.Reviews; }
        }

        // save a review
        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        // update a review
        public Review Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        // delete a review
        public void Remove(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        // delete all reviews
        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("delete from reviews");
        }
    }
}
