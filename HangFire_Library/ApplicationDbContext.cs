using HangFire_Library.Entidades;
using Microsoft.EntityFrameworkCore;

namespace HangFire_Library
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas => Set<Persona>();
    }
}
