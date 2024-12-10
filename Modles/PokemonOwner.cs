using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonReviewApp.Modles
{
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Owner Owner { get; set; }
    }
}
