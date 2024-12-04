using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Find(reviewId);
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            //return _context.Pokemons.Where(p=>p.Id==pokeId).SelectMany(p=>p.Reviews).ToList();
            return _context.Reviews.Where(r=>r.PokemonId==pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(p=>p.Id==reviewId);
        }
    }
}
