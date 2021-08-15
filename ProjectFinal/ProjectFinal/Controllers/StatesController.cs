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
    public class StatesController : Controller
    {

        private readonly ILogger<StatesController> _logger;

        public StatesController(ILogger<StatesController> logger)
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
            var Data = new States().QueryReader("SELECT * FROM werehouse_state");
            ViewBag.Werehouses = Data.DefaultView;
            return View();
        }

        [HttpGet]
        public JsonResult GetStates(string WEREHOUSE_COUNTRY_ID)
        {
            var Data = new States().QueryReader("SELECT * FROM werehouse_state where WEREHOUSE_COUNTRY_ID = " + WEREHOUSE_COUNTRY_ID);

            return Json(Data);
        }
    }
}
