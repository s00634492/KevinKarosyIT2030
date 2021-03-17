﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class Trip
    {
        public int TripID { get; set; }

        [Required(ErrorMessage = "Please enter a destination.")]
        public string Destination { get; set; }
        [Required(ErrorMessage = "Please enter a start date.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please enter an end date.")]
        public DateTime EndDate { get; set; }
        public string Accommodation { get; set; }

        public string AccommodationPhone { get; set; }
        public string AccommodationEmail { get; set; }

        public string ThingToDo1 { get; set; }
        public string ThingToDo2 { get; set; }
        public string ThingToDo3 { get; set; }
    }
}
