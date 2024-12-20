﻿using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int reviewId);
        bool Create(int pokemonId, int reviewerId, Review createreview);
        bool Save();
    }
}
