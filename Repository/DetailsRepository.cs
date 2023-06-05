using Dapper;
using Microsoft.Data.SqlClient;
using WebApplicationApi.Interfaces;
using WebApplicationApi.Models;

namespace WebApplicationApi.Repository
{
    public class DetailsRepository : IDetailsRepository
    {
        private readonly IConfiguration Configuration;

        public DetailsRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<List<Details>> GetAll()
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var detailsGetQuery = @"SELECT * FROM Details";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.Query<Details>(detailsGetQuery).ToList();
            return result;
        }

        public async Task<string> CreateDetails(Details details)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var detailsCreateQuery = @"INSERT INTO [dbo].[Details] ([FilmName], [Country], [Year]) VALUES (@FilmName, @Country, @Year)";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.ExecuteAsync(detailsCreateQuery, details);
            return result.ToString();
        }

        public async Task<string> UpdateDetails(Details details)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var detailsUpdateQuery = @"UPDATE [dbo].[Details] SET [FilmName] = @FilmName ,[Country] = @Country ,[Year] = @Year WHERE [Id] = @Id";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.ExecuteAsync(detailsUpdateQuery, details);
            return result.ToString();
        }

        public async Task<string> DeleteDetails(long id)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");
            
            var detailsDeleteQuery = @"DELETE FROM [Details] WHERE [Id] = @Id";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.ExecuteAsync(detailsDeleteQuery, new {Id = id});
            return result.ToString();
        }

        public async Task<Details> GeTByIdDetails(long id)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");
            
            var actorGetByIdQuery = @"SELECT * FROM [Details] WHERE [Id] = @Id";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.QuerySingleOrDefault<Details>(actorGetByIdQuery, new {Id = id});
            return result;
        }
    }
}
