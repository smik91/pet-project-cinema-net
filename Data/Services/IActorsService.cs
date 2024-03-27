using pet_project.Models;

namespace pet_project.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int id);
        Task AddAsync(Actor actor);
        Actor Update(int id,Actor newActor);
        void Delete(int id);
    }
}
