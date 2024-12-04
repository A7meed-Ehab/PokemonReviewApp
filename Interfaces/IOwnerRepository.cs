using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnersByPokemon(int id);
        ICollection<Pokemon> GetPokemonsByOwner(int id);
        bool Save();
        bool Create(Owner owner);
    }
}
