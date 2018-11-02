using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlexUploader.Models;

namespace PlexUploader.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
        
        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(int id) {
            Debug.WriteLine("UPLOADED:" + id);

            // TODO: DO DATABASE UPLOAD CODE HERE(?)

            return RedirectToAction("", "");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
