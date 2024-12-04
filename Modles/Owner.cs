namespace PokemonReviewApp.Modles
{
    public class Owner:BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<PokemonOwner> PokemonOwners  { get; set; }
    }
}
