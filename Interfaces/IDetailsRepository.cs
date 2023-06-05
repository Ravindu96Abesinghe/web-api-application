using WebApplicationApi.Models;

namespace WebApplicationApi.Interfaces
{
    public interface IDetailsRepository
    {
        Task<List<Details>> GetAll();
        Task<string> CreateDetails(Details details);
        Task<string> UpdateDetails(Details details);
        Task<string> DeleteDetails(long id);
        Task<Details> GeTByIdDetails(long id);
    }
}
