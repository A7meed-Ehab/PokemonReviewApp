namespace PokemonReviewApp.Modles
{
    public class Country:BaseModel
    {
        public string Name { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}
