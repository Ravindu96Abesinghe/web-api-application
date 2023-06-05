using Microsoft.EntityFrameworkCore;
using WebApplicationApi.Interfaces;
using WebApplicationApi.Models;
using WebApplicationApi.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationContextConnection' not found.");



builder.Services.AddDbContext<ActorDbContext>(options =>
 options.UseSqlServer(connectionString)); ;

// Add services to the container.
//Repository
builder.Services.AddScoped<IActorsRepository, ActorsRepository>();
builder.Services.AddScoped<IFilmsRepository, FilmsRepository>();
builder.Services.AddScoped<IIndrustryRepository, IndrustryRepository>();
builder.Services.AddScoped<IDetailsRepository, DetailsRepository>();

// Response
builder.Services.AddSingleton(new ApiResponse(200, true));
builder.Services.AddSingleton(new ApiBadRequestResponse(null));
builder.Services.AddSingleton(new ApiOkResponse(200, "Ok"));

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
