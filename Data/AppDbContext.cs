using Microsoft.EntityFrameworkCore;
using WebApiFilmesSeries.Models;

namespace WebApiFilmesSeries.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Esportes> Esportes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}