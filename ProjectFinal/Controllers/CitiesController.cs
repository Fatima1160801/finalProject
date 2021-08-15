using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectFinal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Controllers
{
    public class CitiesController : Controller
    {

        private readonly ILogger<CitiesController> _logger;

        public CitiesController(ILogger<CitiesController> logger)
        {
            _logger = logger;
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
        public IActionResult Index()
        {
            var Data = new Cities().QueryReader("SELECT * FROM werehouse_city");
            ViewBag.Werehouses = Data.DefaultView;
            return View();
        }

        [HttpGet]
        public JsonResult GetCities(int WEREHOUSE_STATE_ID)
        {
            var Data = new Cities().QueryReader("SELECT * FROM werehouse_city where WEREHOUSE_STATE_ID = " + WEREHOUSE_STATE_ID);

            return Json(Data);
        }
    }
}
