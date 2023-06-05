using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using WebApplicationApi.Interfaces;
using WebApplicationApi.Models;
//using Dapper;

namespace WebApplicationApi.Repository
{
    public class ActorsRepository : IActorsRepository
    {
        private readonly IConfiguration Configuration;

        public ActorsRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public async Task<List<Actors>> GetAll()
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var actorGetQuery = @"SELECT * FROM Actors";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.Query<Actors>(actorGetQuery).ToList();
            return result;
        }

        public async Task<string> CreateActor(Actors actors)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var actorCreateQuery = @"INSERT INTO [dbo].[Actors] ([Name], [Age], [AcademicWinner]) VALUES (@Name, @Age, @AcademicWinner)";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.ExecuteAsync(actorCreateQuery, actors);
            return result.ToString();
        }

        public async Task<string> UpdateActor(Actors actors)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var actorUpdateQuery = @"UPDATE [dbo].[Actors] SET [Name] = @Name ,[Age] = @Age ,[AcademicWinner] = @AcademicWinner WHERE [Id] = @Id";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.ExecuteAsync(actorUpdateQuery, actors);
            return result.ToString();
        }
        
        public async Task<string> DeleteActor(long id)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");
            
            var actorDeleteQuery = @"DELETE FROM [Actors] WHERE [Id] = @Id";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.ExecuteAsync(actorDeleteQuery, new {Id = id});
            return result.ToString();
        }
        
        public async Task<Actors> GeTByIdActor(long id)
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");
            
            var actorGetByIdQuery = @"SELECT * FROM [Actors] WHERE [Id] = @Id";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.QuerySingleOrDefault<Actors>(actorGetByIdQuery, new {Id = id});
            return result;
        }
    }
}
