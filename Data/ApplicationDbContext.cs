using CinemaTicket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Sahne> Sahnes { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Pay> Pays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .HasMany<Screening>(m => m.Screenings)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.MovieId);

            modelBuilder.Entity<Sahne>()
                .HasMany<Screening>(s => s.Screenings)
                .WithOne(sc => sc.Sahne)
                .HasForeignKey(sc => sc.SahneId);

            modelBuilder.Entity<Screening>()
                .HasMany<Ticket>(s => s.Tickets)
                .WithOne(t => t.Screening)
                .HasForeignKey(t => t.ScreeningId);

            // Eğer User sınıfı Identity yerine kullanılacaksa:
            modelBuilder.Entity<User>()
                .HasMany<Ticket>(u => u.Tickets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Ticket>()
                .HasOne<Pay>(t => t.Pay)
                .WithOne(p => p.Ticket)
                .HasForeignKey<Pay>(p => p.TicketId);
        }
    }
}
