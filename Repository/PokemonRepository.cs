using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository:IPokemonRepository
    {
        private readonly AppDbContext _context;

        public PokemonRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public Pokemon GetPokemon(int id)
        {
           return _context.Pokemons.Where(p=>p.Id==id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string Name)
        {
            return _context.Pokemons.Where(p => p.Name == Name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int id)
        {
            var review = _context.Reviews.Where(r => r.PokemonId == id);
            if (review.Count()<0)
            {
                return 0;
            }
            return (decimal)review.Sum(r => r.Rating) / review.Count();
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .ToList();
        }

        public bool PkemonExists(int id)
        {
            return _context.Pokemons.Any(p => p.Id==id);
        }
    }
}
