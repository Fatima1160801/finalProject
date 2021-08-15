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
    public class CountriesController : Controller
    {
        private readonly ILogger<CountriesController> _logger;

        public CountriesController(ILogger<CountriesController> logger)
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
            var Data = new Countries().QueryReader("SELECT * FROM werehouse_contry");
            ViewBag.Werehouses = Data.DefaultView;
            return View();
        }

        [HttpGet]
        public JsonResult GetCountry(int WEREHOUSE_COUNTRY_ID)
        {
            var Data = new Countries().QueryReader("SELECT WEREHOUSE_COUNTRY_NAME FROM werehouse_contry where WEREHOUSE_Country_ID = " + WEREHOUSE_COUNTRY_ID);


            return Json(Data);
        }
    }
}
