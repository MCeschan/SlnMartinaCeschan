using Microsoft.EntityFrameworkCore;
using SistemaWebMisRecetas.Models;

namespace SistemaWebMisRecetas.Data
{
    public class RecetasDBContext: DbContext
    {
        public RecetasDBContext(DbContextOptions<RecetasDBContext> options) : base(options) { }

        public DbSet<Receta> Recetas { get; set; }
    }
}
