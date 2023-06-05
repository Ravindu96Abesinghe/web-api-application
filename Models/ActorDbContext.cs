using Microsoft.EntityFrameworkCore;

namespace WebApplicationApi.Models
{
    public partial class ActorDbContext : DbContext
    {
        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Films> Films { get; set; }
        public virtual DbSet<Details> Details { get; set; }

        public ActorDbContext(DbContextOptions<ActorDbContext> options) : base(options) 
        { 
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
