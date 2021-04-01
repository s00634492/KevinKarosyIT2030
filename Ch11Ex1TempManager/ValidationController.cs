using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempManager.Models;

namespace TempManager.Controllers
{
    public class ValidationController : Controller
    {
        private TempManagerContext context;
        public ValidationController(TempManagerContext ctx) => context = ctx;
        
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CheckDate(string date)
        {
            DateTime myDate;
            try { myDate = Convert.ToDateTime(date); }
            catch { return Json("Date unrecognized."); }

            Temp query = context.Temps.FirstOrDefault(t => t.Date == myDate);

            if (query == null) return Json(true);
            else return Json("That date has already been recorded.");
        }
    }
}
