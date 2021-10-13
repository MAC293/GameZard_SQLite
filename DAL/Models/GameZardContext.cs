using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class GameZardContext : DbContext
    {
        public GameZardContext()
        {
        }

        public GameZardContext(DbContextOptions<GameZardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Emulator> Emulators { get; set; }
        public virtual DbSet<SavedataEmulator> SavedataEmulators { get; set; }
        public virtual DbSet<SavedataPc> SavedataPcs { get; set; }
        public virtual DbSet<Videogame> Videogames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlite("Data Source=..\\DAL\\GameZard.db;");
                optionsBuilder.UseSqlite("Data Source=E:\\Projects\\IT\\GameZard\\Solutions\\GameZard_SQLite\\DAL\\GameZard.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emulator>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("Emulator");

                entity.Property(e => e.Console).IsRequired();
            });

            modelBuilder.Entity<SavedataEmulator>(entity =>
            {
                entity.ToTable("SavedataEmulator");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BackUpMode).IsRequired();

                entity.Property(e => e.FromPath).IsRequired();

                entity.Property(e => e.LastSaved).IsRequired();

                entity.Property(e => e.ToPath).IsRequired();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.SavedataEmulator)
                    .HasForeignKey<SavedataEmulator>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SavedataPc>(entity =>
            {
                entity.ToTable("SavedataPC");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BackUpMode).IsRequired();

                entity.Property(e => e.FromPath).IsRequired();

                entity.Property(e => e.LastSaved).IsRequired();

                entity.Property(e => e.ToPath).IsRequired();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.SavedataPc)
                    .HasForeignKey<SavedataPc>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Videogame>(entity =>
            {
                entity.ToTable("Videogame");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
