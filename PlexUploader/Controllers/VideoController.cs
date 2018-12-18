using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlexUploader.Models;
using MySql.Data.MySqlClient;

namespace PlexUploader.Controllers
{
    public class VideoController : Controller
    {

        private readonly IConfiguration configuration;
        MySqlConnection conn;

        public VideoController(IConfiguration config)
        {
            this.configuration = config;
        }

        public IActionResult Index()
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");

            List<VideoModel> videos = new List<VideoModel>();

            try
            {
                conn = new MySqlConnection(connStr);

                conn.Open();

                string sql = "Select * from video";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {
                    videos.Add(new VideoModel { Name = rdr.GetString("name"), Type = rdr.GetString("type"), Created = rdr.GetDateTime("create_time") });
                }

            }
            catch (MySqlException ex)
            {
                throw new Exception("The database connection state is Closed");

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        

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
