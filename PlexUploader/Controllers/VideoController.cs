using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlexUploader.Models;

namespace PlexUploader.Controllers
{
    public class VideoController : Controller
    {

        public IActionResult Index()
        {
            List<VideoModel> videos = new List<VideoModel>();

            videos.Add(new VideoModel { Name = "How I met", Type = "Tv Show", Created = DateTime.Today });
            videos.Add(new VideoModel { Name = "Skater", Type = "Tv Show", Created = DateTime.Today });
            videos.Add(new VideoModel { Name = "Star Wars", Type = "Movie", Created = DateTime.Today });
            videos.Add(new VideoModel { Name = "Wayne's World", Type = "Movie", Created = DateTime.Today });


            return View(videos);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
