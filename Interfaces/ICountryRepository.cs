using PokemonReviewApp.Dto;
using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetById(int id);
        Country GetByName(string name);
        IEnumerable<Owner> GetOwnersFromCountry(int id);
        Country GetCountryByOwner(int ownerId);
        bool CountryExists(int id);
        bool Save();
        bool Create(Country country );

    }
}
