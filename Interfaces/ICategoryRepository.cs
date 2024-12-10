using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int CategoryId);
        ICollection<Pokemon> GetPokemonByCategory(int CategoryId);
        bool CategoriesExists(string name);
        bool CategoriesExists(int  id);
        bool Create(Category category);
        bool UpdateCategory(Category category);
        bool Save(); 
       
    }
}
