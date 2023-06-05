using WebApplicationApi.Models;

namespace WebApplicationApi.Interfaces;

public interface IIndrustryRepository
{
    Task<IEnumerable<Actors>> GetActorsFilm();
    Task<IEnumerable<Actors>> GetDetails();
}