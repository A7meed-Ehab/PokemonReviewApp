using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public bool Create(Country country)
        {
            _context.Countries.Add(country);
            return Save();
        }

        public Country GetById(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetByName(string name)
        {
            return _context.Countries.Where(c => c.Name.ToLower() == name.ToLower()).FirstOrDefault();
            
        }

        public ICollection<Country> GetCountries()
        {
         return _context.Countries.ToList();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public IEnumerable<Owner> GetOwnersFromCountry(int id)
        {
            //return _context.Countries.Where(c => c.Id == id).SelectMany(c => c.Owners);
            return _context.Owners.Where(o => o.CountryId == id).ToList();
        }

        public bool Save()
        {
            var isSaved = _context.SaveChanges();
            return isSaved >0 ? true : false;   

        }

        public bool Update(Country country)
        {
            _context.Countries.Update(country);
            return Save();
        }
    }
}
