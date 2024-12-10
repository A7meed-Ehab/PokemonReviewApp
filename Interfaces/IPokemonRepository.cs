using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string Name);
        decimal GetPokemonRating(int id);
        bool PkemonExists(int id);
        bool Create(int categoryId, int ownerId, Pokemon model);
        bool Update(int categoryId, string s, Pokemon model);
        bool Save();

    }
}
