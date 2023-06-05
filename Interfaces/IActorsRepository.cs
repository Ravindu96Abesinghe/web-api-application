using WebApplicationApi.Models;

namespace WebApplicationApi.Interfaces
{
    public interface IActorsRepository
    {
        Task<List<Actors>> GetAll();
        Task<string> CreateActor(Actors actors);
        Task<string> UpdateActor(Actors actors);
        Task<string> DeleteActor(long id);
        Task<Actors> GeTByIdActor(long id);

    }
}
