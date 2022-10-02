using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.Legacy
{
    public partial class HEROAPPContext : DbContext
    {
        public HEROAPPContext()
        {
        }

        public HEROAPPContext(DbContextOptions<HEROAPPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Battles> Battles { get; set; }
        public virtual DbSet<HeroBattles> HeroBattles { get; set; }
        public virtual DbSet<Heroes> Heroes { get; set; }
        public virtual DbSet<SecretIdentities> SecretIdentities { get; set; }
        public virtual DbSet<Weapons> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Password=33385412VR.jp@;Persist Security Info=True;User ID=sa;Initial Catalog=HEROAPP;Data Source=NOTEBOOK-DELL");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<HeroBattles>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroId });

                entity.HasIndex(e => e.BattleId);

                entity.HasIndex(e => e.HeroId);

                entity.HasOne(d => d.Battle)
                    .WithMany(p => p.HeroBattles)
                    .HasForeignKey(d => d.BattleId);

                entity.HasOne(d => d.Hero)
                    .WithMany(p => p.HeroBattles)
                    .HasForeignKey(d => d.HeroId);
            });

            modelBuilder.Entity<SecretIdentities>(entity =>
            {
                entity.HasIndex(e => e.HeroId)
                    .IsUnique();

                entity.HasOne(d => d.Hero)
                    .WithOne(p => p.SecretIdentities)
                    .HasForeignKey<SecretIdentities>(d => d.HeroId);
            });

            modelBuilder.Entity<Weapons>(entity =>
            {
                entity.HasIndex(e => e.HeroiId);

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.HeroiId);
            });
        }
    }
}
