using WebApplicationApi.Models;

namespace WebApplicationApi.Interfaces
{

    public interface IFilmsRepository
    {
        Task<List<Films>> GetAll();
        Task<string> CreateFilm(Films films);
        Task<string> UpdateFilm(Films films);
        Task<string> DeleteFilm(long id);
        Task<Films> GetByNameFilm(string name);
    }
}