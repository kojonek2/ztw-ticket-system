﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservationAPI.Data;

namespace ReservationAPI.Migrations
{
    [DbContext(typeof(ReservationsDbContext))]
    partial class ReservationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReservationAPI.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GraphicId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainCarId")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("GraphicId")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("ReservationAPI.Models.Connection", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<int?>("FirstStationId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("SecondStationId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ConnectionId");

                    b.HasIndex("FirstStationId");

                    b.HasIndex("SecondStationId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("ReservationAPI.Models.Graphic", b =>
                {
                    b.Property<int>("GraphicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("GraphicId");

                    b.ToTable("Graphics");
                });

            modelBuilder.Entity("ReservationAPI.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("PlaceId");

                    b.HasIndex("CarId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("ReservationAPI.Models.PlaceReservation", b =>
                {
                    b.Property<int>("PlaceReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("TicketTypeId")
                        .HasColumnType("int");

                    b.HasKey("PlaceReservationId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("ReservationId");

                    b.HasIndex("TicketTypeId");

                    b.ToTable("PlaceReservations");
                });

            modelBuilder.Entity("ReservationAPI.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FromId")
                        .HasColumnType("int");

                    b.Property<int>("ToId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("ReservationAPI.Models.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("StationId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("ReservationAPI.Models.Stop", b =>
                {
                    b.Property<int>("StopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StopDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("StopId");

                    b.HasIndex("StationId");

                    b.HasIndex("TrainId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("ReservationAPI.Models.TicketType", b =>
                {
                    b.Property<int>("TicketTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePercentage")
                        .HasColumnType("float");

                    b.HasKey("TicketTypeId");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("ReservationAPI.Models.Train", b =>
                {
                    b.Property<int>("TrainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.HasKey("TrainId");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("ReservationAPI.Models.TrainCars", b =>
                {
                    b.Property<int>("TrainCarsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainCarsId");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("TrainId");

                    b.ToTable("TrainCars");
                });

            modelBuilder.Entity("ReservationAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ReservationAPI.Models.Car", b =>
                {
                    b.HasOne("ReservationAPI.Models.Graphic", "Graphic")
                        .WithOne("Car")
                        .HasForeignKey("ReservationAPI.Models.Car", "GraphicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Graphic");
                });

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

            modelBuilder.Entity("ReservationAPI.Models.Place", b =>
                {
                    b.HasOne("ReservationAPI.Models.Car", "Car")
                        .WithMany("Places")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("ReservationAPI.Models.PlaceReservation", b =>
                {
                    b.HasOne("ReservationAPI.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservationAPI.Models.Reservation", "Reservation")
                        .WithMany("PlaceReservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservationAPI.Models.TicketType", "TicketType")
                        .WithMany()
                        .HasForeignKey("TicketTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("Reservation");

                    b.Navigation("TicketType");
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

                    b.HasOne("ReservationAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("To");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReservationAPI.Models.Stop", b =>
                {
                    b.HasOne("ReservationAPI.Models.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservationAPI.Models.Train", "Train")
                        .WithMany("Stops")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("ReservationAPI.Models.TrainCars", b =>
                {
                    b.HasOne("ReservationAPI.Models.Car", "Car")
                        .WithOne("TrainCar")
                        .HasForeignKey("ReservationAPI.Models.TrainCars", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservationAPI.Models.Train", "Train")
                        .WithMany("TrainCars")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("ReservationAPI.Models.Car", b =>
                {
                    b.Navigation("Places");

                    b.Navigation("TrainCar");
                });

            modelBuilder.Entity("ReservationAPI.Models.Graphic", b =>
                {
                    b.Navigation("Car");
                });

            modelBuilder.Entity("ReservationAPI.Models.Reservation", b =>
                {
                    b.Navigation("PlaceReservations");
                });

            modelBuilder.Entity("ReservationAPI.Models.Train", b =>
                {
                    b.Navigation("Stops");

                    b.Navigation("TrainCars");
                });
#pragma warning restore 612, 618
        }
    }
}
