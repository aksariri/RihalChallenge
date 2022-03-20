using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.Data
{
    public class RihalChallengeContext : DbContext
    {
        public RihalChallengeContext()
        { }
        #region Contructor
        public RihalChallengeContext(DbContextOptions<RihalChallengeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        #region Public_Properties
        public virtual DbSet<students> students { get; set; }
        public virtual DbSet<classes> classes { get; set; }
        public virtual DbSet<countries> countries { get; set; }
        #endregion

        #region Overidden_Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<students>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("tb_students");

                entity.Property(e => e.class_Id).HasColumnType("integer");
                entity.Property(e => e.country_Id);
                entity.Property(e => e.name).HasColumnType("text");
                entity.Property(e => e.date_of_birth)
                    .HasColumnType("date");
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifitedDate).HasColumnType("datetime");               

                entity.HasOne(d => d.Classes)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.class_Id)
                    .HasConstraintName("FK_Students_Classes");

                entity.HasOne(d => d.Countries)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.country_Id)
                    .HasConstraintName("FK_Students_Countries");
            });
            modelBuilder.Entity<classes>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("tb_classes");
                entity.Property(e => e.name).HasColumnType("text");
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifitedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<countries>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("tb_countries");
                entity.Property(e => e.name).HasColumnType("text");
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifitedDate).HasColumnType("datetime");
            });

        }
        #endregion
    }
}
