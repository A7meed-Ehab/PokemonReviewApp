using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly AppDbContext _context;

        public ReviewerRepository(AppDbContext appDbContext )
        {
            this._context = appDbContext;
        }
        public Reviewer GetReviewer(int reviewerId)
        {
            return _context.Reviewers.Find(reviewerId);
        }

        public ICollection<Reviewer> GetReviewers()
        {
           return _context.Reviewers.ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            //return _context.Reviewers.Where(r => r.Id == reviewerId).SelectMany(x=>x.Reviews).ToList();
            return _context.Reviews.Where(r => r.ReviewerId == reviewerId).ToList();    
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _context.Reviews.Any(r => r.Id == reviewerId);
        }
    }
}
