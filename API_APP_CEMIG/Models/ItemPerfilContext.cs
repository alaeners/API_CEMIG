using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public class ItemPerfilContext : DbContext
    {
        public ItemPerfilContext(DbContextOptions<ItemPerfilContext> options)
        : base(options)
        { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<ItemPerfil> ItemPerfil { get; set; }
        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPerfil>()
                .HasKey(c => new { c.NumPerfil, c.IdItem });
        }
    }
}
