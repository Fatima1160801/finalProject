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
    public class TypesController : Controller
    {
        private readonly ILogger<TypesController> _logger;

        public TypesController(ILogger<TypesController> logger)
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
            var Data = new Types().QueryReader("SELECT * FROM werehouse_type");
            ViewBag.Werehouses = Data.DefaultView;
            return View();
        }

        [HttpGet]
        public JsonResult GetTypes(int WEREHOUSE_TYPE_ID)
        {
            var Data = new Types().QueryReader("SELECT WEREHOUSE_TYPE_NAME FROM werehouse_type ");

            return Json(Data);
        }
    }
}
