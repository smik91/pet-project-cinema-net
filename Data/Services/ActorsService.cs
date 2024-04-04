using Microsoft.EntityFrameworkCore;
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
            var result = await _context.Actors.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var actor = await _context.Actors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return actor;
        }

        public async Task UpdateAsync(Actor newActor)
        {
            var actorToUpdate = await _context.Actors.FirstOrDefaultAsync(x => x.Id == newActor.Id);
            if (actorToUpdate != null)
            {
                actorToUpdate.ProfilePictureURL = newActor.ProfilePictureURL;
				actorToUpdate.FullName = newActor.FullName;
				actorToUpdate.Bio = newActor.Bio;
                await _context.SaveChangesAsync();
			}
        }
    }
}