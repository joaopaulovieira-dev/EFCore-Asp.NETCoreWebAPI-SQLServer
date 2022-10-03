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
        public HeroContext()
        {

        }
        public HeroContext(DbContextOptions<HeroContext> options) : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<HeroBattle> HeroBattles { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=33385412VR.jp@;Persist Security Info=True;User ID=sa;Initial Catalog=HEROAPP;Data Source=NOTEBOOK-DELL");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroBattle>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroId });
            });
        }
    }
}
