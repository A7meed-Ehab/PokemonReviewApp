﻿using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        public bool CategoriesExists(string name)
        {
            return _context.Categories.Any(e=>e.Name.ToLower()==name.ToLower());
        }

        public bool CategoriesExists(int id)
        {
            return _context.Categories.Any(c=>c.Id==id);
        }

        public bool Create(Category category)
        {
            _context.Categories.Add(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int CategoryId)
        {
            return _context.Categories.Where(c => c.Id == CategoryId).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int id)
        {
            return _context.PokemonCategories.Where(pc=>pc.CategoryId==id).Select(c=>c.Pokemon).ToList();
        }

        public bool Save()
        {
            var isSaved = _context.SaveChanges();
            return isSaved > 0 ? true: false; 
        }

        public bool UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
           return Save();
        }
    }
}
