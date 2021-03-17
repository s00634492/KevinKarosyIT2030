using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private TripContext context { get; set; }

        public HomeController(TripContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index()
        {
            ViewData["message"] = TempData["message"];
            
            var trips = context.Trips.OrderBy(m => m.TripID).ToList();
            return View(trips);
        }

        public RedirectToActionResult Delete(int id)
        {
            var trip = context.Trips.Find(id);
            context.Trips.Remove(trip);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
