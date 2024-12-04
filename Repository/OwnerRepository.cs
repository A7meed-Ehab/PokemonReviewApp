﻿using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly AppDbContext _context;

        public OwnerRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public bool Create(Owner owner)
        {
            _context.Owners.Add(owner);
           return Save();
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Find(ownerId);
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Owner> GetOwnersByPokemon(int id)
        {
            return _context.PokemonOwners.Where(p => p.PokemonId == id).Select(o=>o.Owner).ToList();
        }

        public ICollection<Pokemon> GetPokemonsByOwner(int id)
        {
            return _context.PokemonOwners.Where(p => p.OwnerId == id).Select(o => o.Pokemon).ToList();
        }

        public bool Save()
        {
           var isSaved= _context.SaveChanges();
           return isSaved > 0 ? true:false;
        }
    }
}
