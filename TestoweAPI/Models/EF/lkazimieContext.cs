using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestoweAPI.Models.EF
{
    public partial class lkazimieContext : DbContext
    {
        public lkazimieContext()
        {
        }

        public lkazimieContext(DbContextOptions<lkazimieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<RentMovie> RentMovie { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=lkazimie.mssql.somee.com;Initial Catalog=lkazimie;Persist Security Info=True;User ID=lukasz82_SQLLogin_1;Password=418fjse1c7");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.GenreId);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasIndex(e => e.AuthorId);

                entity.HasIndex(e => e.GenreId);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.GenreId);
            });

            modelBuilder.Entity<RentMovie>(entity =>
            {
                entity.HasIndex(e => e.MovieId)
                    .IsUnique();

                entity.HasOne(d => d.Movie)
                    .WithOne(p => p.RentMovie)
                    .HasForeignKey<RentMovie>(d => d.MovieId);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasIndex(e => e.MovieId);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.MovieId);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.ReviewId);

                entity.HasIndex(e => e.MovieId);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MovieId);
            });
        }
    }
}
