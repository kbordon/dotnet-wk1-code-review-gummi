using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace GummiBearKingdom.Models
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        Review Save(Review review);
        Review Edit(Review review);
        void Remove(Review review);
    }
}
