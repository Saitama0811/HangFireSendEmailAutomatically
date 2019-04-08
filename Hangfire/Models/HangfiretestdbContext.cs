using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hangfire.Models
{
    public partial class HangfiretestdbContext : DbContext
    {
        public HangfiretestdbContext()
        {
        }

        public HangfiretestdbContext(DbContextOptions<HangfiretestdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hangfiretbl> Hangfiretbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=Hangfiretestdb;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Hangfiretbl>(entity =>
            {
                entity.ToTable("hangfiretbl");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DatePosted).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });
        }
    }
}
