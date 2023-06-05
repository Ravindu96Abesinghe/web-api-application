using Dapper;
using Microsoft.Data.SqlClient;
using WebApplicationApi.Interfaces;
using WebApplicationApi.Models;

namespace WebApplicationApi.Repository
{

    public class FilmsRepository : IFilmsRepository
    {
        private readonly IConfiguration Configuration;

        public FilmsRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<List<Films>> GetAll()
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var filmGetQuery = @"SELECT * FROM Films";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.Query<Films>(filmGetQuery).ToList();
            return result;
        }

        public async Task<string> CreateFilm(Films films)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var filmCreateQuery =
                @"INSERT INTO [dbo].[Films] ([Name], [Author], [ParentId]) VALUES (@Name, @Author, @ParentId)";

            await using var connection = new SqlConnection(connectionString);
            var result = await connection.ExecuteAsync(filmCreateQuery, films);
            return result.ToString();
        }

        public async Task<string?> UpdateFilm(Films films)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var filmUpdateQuery =
                @"UPDATE [dbo].[Films] SET [Name] = @Name ,[Author] = @Author ,[ParentId] = @ParentId WHERE [Id] = @Id";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.ExecuteAsync(filmUpdateQuery, films);
            return result.ToString();
        }

        public async Task<string> DeleteFilm(long id)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var filmDeleteQuery = @"DELETE FROM [Films] WHERE [Id] = @Id";

            await using var connection = new SqlConnection(connectionString);
            var result = await connection.ExecuteAsync(filmDeleteQuery, new { Id = id });
            return result.ToString();
        }
        

        public async Task<Films> GetByNameFilm(string name)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var filmGetByNameQuery = @"SELECT * FROM [Films] WHERE [Name] = @Name";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.QuerySingleOrDefault<Films>(filmGetByNameQuery, new { Name = name });
            return result;
        }
    }
}