using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ReservationAPI.Models;

namespace ReservationAPI.Data
{
    public class ReservationsDbContext : DbContext
    {
        public ReservationsDbContext(DbContextOptions<ReservationsDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Graphic> Graphics { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceReservation> PlaceReservations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainCars> TrainCars { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity("ReservationAPI.Models.Connection", b =>
            {
                b.HasOne("ReservationAPI.Models.Station", "FirstStation")
                    .WithMany()
                    .HasForeignKey("FirstStationId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.HasOne("ReservationAPI.Models.Station", "SecondStation")
                    .WithMany()
                    .HasForeignKey("SecondStationId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.Navigation("FirstStation");

                b.Navigation("SecondStation");
            });

            modelBuilder.Entity("ReservationAPI.Models.Reservation", b =>
            {
                b.HasOne("ReservationAPI.Models.Stop", "From")
                    .WithMany()
                    .HasForeignKey("FromId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.HasOne("ReservationAPI.Models.Stop", "To")
                    .WithMany()
                    .HasForeignKey("ToId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.Navigation("From");

                b.Navigation("To");
            });

            modelBuilder.Entity<PlaceReservation>()
                .HasOne(pr => pr.TrainCars)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
