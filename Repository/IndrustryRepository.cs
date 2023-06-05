using Dapper;
using Microsoft.Data.SqlClient;
using WebApplicationApi.Interfaces;
using WebApplicationApi.Models;

namespace WebApplicationApi.Repository;

public class IndrustryRepository : IIndrustryRepository
{
    private readonly IConfiguration Configuration;

    public IndrustryRepository(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public async Task<IEnumerable<Actors>> GetActorsFilm()
    {
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var actorsFilmsGetQuery = @"SELECT * FROM [dbo].[Actors] a INNER JOIN [WebApplication1].[dbo].[Films] f ON a.Id = f.ParentId;";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.Query<Actors, Films, Actors>(actorsFilmsGetQuery, (actor, film) =>
                {
                    actor.Films = film;
                    return actor;
                },
                splitOn: "Name");
            return result;
        }
    }
    
    
    public async Task<IEnumerable<Actors>> GetDetails()
    {
        {
            var connectionString = Configuration.GetConnectionString("ApplicationContextConnection");

            var getDetailsQuery = @"SELECT a.[Id] ,a.[Name] ,a.[Age] ,a.[AcademicWinner] ,f.[Id],f.[Author] ,d.[Id],d.[FilmName] ,d.[Country] ,d.[Year]
                                        FROM [WebApplication1].[dbo].[Actors] a 
                                        INNER JOIN [WebApplication1].[dbo].[Films] f ON a.[Id] = f.[ParentId] 
                                        INNER JOIN [WebApplication1].[dbo].[Details] d ON d.[FilmName] = f.[Name];";

            await using var connection = new SqlConnection(connectionString);
            var result = connection.Query<Actors, Films, Details, Actors>(getDetailsQuery, (actor, film, details) =>
                {
                    actor.Films = film;
                    film.Details = details;
                    return actor;
                },
                splitOn: "Id,Id");
            return result;
        }
    }
}