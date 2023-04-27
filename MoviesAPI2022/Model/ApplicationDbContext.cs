using Microsoft.EntityFrameworkCore;

namespace MoviesAPI2022.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<CreateGenreDto> Genres { get; set; }    
    }
}
