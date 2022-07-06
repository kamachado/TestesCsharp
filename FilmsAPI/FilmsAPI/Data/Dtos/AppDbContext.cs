using FilmsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>()
                .HasOne(Address => Address.Cinema)
                .WithOne(Cinema => Cinema.Address)
                .HasForeignKey<Cinema>(cinema => cinema.AddressId);

            builder.Entity<Cinema>()
               .HasOne(cinema => cinema.Manager)
               .WithMany(manager => manager.Cinemas)
               .HasForeignKey(cinema => cinema.ManagerId);

            builder.Entity<Session>()
                .HasOne(session => session.Film)
                .WithMany(film => film.Session)
                .HasForeignKey(sessao => sessao.FilmId);

            builder.Entity<Session>()
                .HasOne(session => session.Cinema)
                .WithMany(cinema => cinema.Session)
                .HasForeignKey(session=> session.CinemaId);
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Manager> Manager{ get; set; }
        public DbSet<Session> Session { get; set; }
    }
}