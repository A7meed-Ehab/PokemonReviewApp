using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly AppDbContext _context;


        public PokemonRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;

        }

        public bool Create(int categoryId, int ownerId, Pokemon model)
        {
            var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                CategoryId = category.Id,
                Pokemon = model,
                PokemonId = model.Id
            };
            _context.Add(pokemonCategory);
            var owner = _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
            var pokemonOwner = new PokemonOwner()
            {
                Owner = owner,
                OwnerId = owner.Id,
                Pokemon = model,
                PokemonId = model.Id
            };
            _context.Add(pokemonOwner);
            _context.Add(model);
            return Save();
        }
        public Pokemon GetPokemon(int pokemonId)
        {
            return _context.Pokemons.AsNoTracking().Where(p => p.Id == pokemonId).FirstOrDefault();
        }

        public Pokemon GetPokemon(string Name)
        {
            return _context.Pokemons.AsNoTracking().Where(p => p.Name == Name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int id)
        {
            var review = _context.Reviews.Where(r => r.PokemonId == id);
            if (review.Count() < 0)
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
            return _context.Pokemons.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(int categoryId,string? CategoryName, Pokemon model)
        {
            if(CategoryName != null) { 
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            category.Name = CategoryName;
            _context.Categories.Update(category);
            }
            _context.Pokemons.Update(model);
            return Save();
        }
    } 
}
