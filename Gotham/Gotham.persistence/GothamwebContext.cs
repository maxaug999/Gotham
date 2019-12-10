using Microsoft.EntityFrameworkCore;

namespace Gotham.web.Models
{
    public class GothamwebContext : DbContext
    {
        public GothamwebContext (DbContextOptions<GothamwebContext> options)
            : base(options)
        {
        }

        public DbSet<Gotham.domain.Nouvelle> Nouvelle { get; set; }
<<<<<<< HEAD
=======
        public DbSet<Gotham.domain.Capsule> Capsule { get; set; }
        public DbSet<Gotham.domain.Alerte> Alerte { get; set; }
>>>>>>> a6f5ce06e0afb0d0db0a5eec11f0ac4bed605462
    }
}
