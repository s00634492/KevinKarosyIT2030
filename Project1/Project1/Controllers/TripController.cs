using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Models;
using Microsoft.EntityFrameworkCore;

namespace Project1.Controllers
{
    [Route("/[controller]/Add/[action]/{id?}")]
    public class TripController : Controller
    {
        private TripContext context { get; set; }

        public TripController(TripContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public ViewResult Page1()
        {
            var trip = new Trip{
                StartDate = DateTime.Today,
                EndDate = DateTime.Today
            };
            
            return View(trip);
        }
        [HttpPost]
        public IActionResult Page1(Trip trip)
        {
            if (ModelState.IsValid==false)
                return View(trip);

            TempData["Destination"] = trip.Destination;
            TempData["Accommodation"] = trip.Accommodation;
            TempData["StartDate"] = trip.StartDate;
            TempData["EndDate"] = trip.EndDate;

            if (trip.Accommodation == null){
                return RedirectToAction("Page3");
            }else{
                return RedirectToAction("Page2");
            }
        }

        [HttpGet]
        public ViewResult Page2()
        {
            return View(new Trip{ Destination="~"});
        }
        [HttpPost]
        public IActionResult Page2(Trip trip)
        {
            if (ModelState.IsValid == false)
                return View(trip);

            TempData["AccommodationPhone"] = trip.AccommodationPhone;
            TempData["AccommodationEmail"] = trip.AccommodationEmail;

            return RedirectToAction("Page3");
        }

        [HttpGet]
        public ViewResult Page3()
        {
            return View(new Trip{Destination="~"});
        }
        [HttpPost]
        public IActionResult Page3(Trip trip)
        {
            if (ModelState.IsValid == false)
                return View(trip);

            var finalTrip = new Trip{
                Destination = TempData["Destination"].ToString(),
                Accommodation = TempData?["Accommodation"]?.ToString(),
                StartDate = (DateTime)TempData["StartDate"],
                EndDate = (DateTime)TempData["EndDate"],
                AccommodationPhone = TempData?["AccommodationPhone"]?.ToString(),
                AccommodationEmail = TempData?["AccommodationEmail"]?.ToString(),
                ThingToDo1 = trip.ThingToDo1,
                ThingToDo2 = trip.ThingToDo2,
                ThingToDo3 = trip.ThingToDo3
            };

            context.Add(finalTrip);
            context.SaveChanges();

            TempData["message"]="Trip to "+finalTrip.Destination+" added.";

            return RedirectToAction("Index","Home");
        }

        public RedirectToActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}
