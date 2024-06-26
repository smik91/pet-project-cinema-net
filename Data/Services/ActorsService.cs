﻿using Microsoft.EntityFrameworkCore;
using pet_project.Models;

namespace pet_project.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var actorDelete = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actorDelete != null)
            {
                _context.Actors.Remove(actorDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}