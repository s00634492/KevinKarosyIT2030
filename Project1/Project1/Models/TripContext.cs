using System;
using Microsoft.EntityFrameworkCore;

namespace Project1.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) { }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasData(
                new Trip{
                    TripID = 1,
                    Destination = "Cleveland",
                    StartDate = new DateTime(2021, 3, 16, 0, 0, 0, 0),
                    EndDate = new DateTime(2021, 3, 17, 0, 0, 0, 0),
                    Accommodation = "Kingston Hotel",
                    AccommodationPhone = "5551234",
                    AccommodationEmail = "help@kingston.com",
                    ThingToDo1 = "Eat cake"
                },new Trip{
                    TripID = 2,
                    Destination = "Miami",
                    StartDate = new DateTime(2021, 3, 18, 0, 0, 0, 0),
                    EndDate = new DateTime(2021, 3, 19, 0, 0, 0, 0),
                    Accommodation = "Beachy Hotel",
                    AccommodationPhone = "5554312",
                    AccommodationEmail = "help@beachy.com",
                    ThingToDo1 = "Swim in ocean"
                },new Trip{
                    TripID = 3,
                    Destination = "Las Vegas",
                    StartDate = new DateTime(2021, 3, 20, 0, 0, 0, 0),
                    EndDate = new DateTime(2021, 3, 21, 0, 0, 0, 0),
                    Accommodation = "Valley Hotel",
                    AccommodationPhone = "5551212",
                    AccommodationEmail = "help@valley.com",
                    ThingToDo1 = "Visit Area51",
                    ThingToDo2 = "See a show"
                });
        }
    }
}
