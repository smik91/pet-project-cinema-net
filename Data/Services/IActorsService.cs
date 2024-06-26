﻿using pet_project.Models;

namespace pet_project.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int id,Actor newActor);
        Task DeleteAsync(int id);
    }
}
