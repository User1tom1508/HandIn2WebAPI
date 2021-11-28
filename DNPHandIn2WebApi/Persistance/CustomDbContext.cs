using DNPHandIn2WebApi.Model;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DNPHandIn2WebApi.Persistance
{
    public class CustomDbContext: DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job>   Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = VIA.db");
        }
    }
}
