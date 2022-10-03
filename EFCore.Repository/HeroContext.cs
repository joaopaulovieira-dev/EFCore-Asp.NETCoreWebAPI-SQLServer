using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options) : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<HeroBattle> HeroBattles { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroBattle>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroId });
            });
        }
    }
}
