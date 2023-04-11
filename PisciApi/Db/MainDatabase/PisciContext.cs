using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Db.MainDatabase
{
    public partial class PisciContext : DbContext
    {
        public PisciContext()
        {
        }

        public PisciContext(DbContextOptions<PisciContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pisci> Piscis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pisci>(entity =>
            {
                entity.ToTable("Pisci");

                entity.Property(e => e.Drzava)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
