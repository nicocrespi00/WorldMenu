using BackendWM.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendWM.Data
{
    public class WorldMenuContext : DbContext
    {
        public WorldMenuContext()
        {

        }

        public WorldMenuContext(DbContextOptions<WorldMenuContext> options) : base(options) 
        { 

        }

        public DbSet<Plato> Plato { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<PlatoIngrediente> PlatoIngrediente { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Initial Catalog=WorldMenu;Integrated Security=True;Connection Timeout=30;Encrypt=False;TrustServerCertificate=false;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
