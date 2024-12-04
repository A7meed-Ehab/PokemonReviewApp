using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int CategoryId);
        ICollection<Pokemon> GetPokemonByCategory(int CategoryId);
        bool CategoriesExists(int CategoryId);
        bool Save();
        bool Create(Category category);
    }
}
