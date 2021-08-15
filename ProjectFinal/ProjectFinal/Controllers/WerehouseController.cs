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
    public class WerehouseController : Controller
    {
        private readonly ILogger<WerehouseController> _logger;

        public WerehouseController(ILogger<WerehouseController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Data = new Werehouses().QueryReader("SELECT * FROM werehouse");
            var Data1 = new Countries().QueryReader("SELECT * FROM werehouse_country");
            var Data2 = new Cities().QueryReader("SELECT * FROM werehouse_city");
            var Data3 = new Types().QueryReader("SELECT * FROM werehouse_type");
            var Data4 = new States().QueryReader("SELECT * FROM werehouse_state");
            
            ViewBag.Werehouses = Data.DefaultView;
            ViewBag.Countries = Data1.DefaultView;
            ViewBag.Cities = Data2.DefaultView;
            ViewBag.Types = Data3.DefaultView;
            ViewBag.States = Data4.DefaultView;

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

      
        public int DeleteWerehouse(string WEREHOUSE_ID)
        {
            var DELETED_WEREHOUSE_ID = new Werehouses().QueryReader("SELECT count(*) as counter FROM items WHERE WEREHOUSE_ID = " + WEREHOUSE_ID);
            var x = DELETED_WEREHOUSE_ID.Rows[0]["counter"].ToString();
            int count = int.Parse(x);
            if (count  == 0)
            {
                var DELETED_WEREHOUSEID = new Werehouses().DELETE_WEREHOUSE(WEREHOUSE_ID);
                return 1;
            }
            else
                return 0;


        }
        [HttpPost]
        public string AddWerehouse(string WEREHOUSE_ID, string WEREHOUSE_NAME, string WEREHOUSE_ADDRESS, string WEREHOUSE_TELEPHON, string WEREHOUSE_DEFULTE
            , string WEREHOUSE_TYPE_ID, string WEREHOUSE_COUNTRY_ID, string WEREHOUSE_STATE_ID, string WEREHOUSE_CITY_ID)
        {


            var newStudent = new Werehouses().Insert_C_PASSPORT_TYPES_TB(WEREHOUSE_ID,  WEREHOUSE_NAME,  WEREHOUSE_ADDRESS, WEREHOUSE_TELEPHON,  WEREHOUSE_DEFULTE
            , WEREHOUSE_TYPE_ID, WEREHOUSE_COUNTRY_ID,  WEREHOUSE_STATE_ID,  WEREHOUSE_CITY_ID);

            return WEREHOUSE_NAME;
        }
       public string UpdateWerehouse(string WEREHOUSE_ID, string WEREHOUSE_NAME, string WEREHOUSE_ADDRESS, string WEREHOUSE_TELEPHON, string WEREHOUSE_DEFULTE
            , string WEREHOUSE_TYPE_ID, string WEREHOUSE_COUNTRY_ID, string WEREHOUSE_STATE_ID, string WEREHOUSE_CITY_ID)
          {


              var edit_stu = new Werehouses().UPDATE_WEREHOUSE(WEREHOUSE_ID, WEREHOUSE_NAME, WEREHOUSE_ADDRESS, WEREHOUSE_TELEPHON, WEREHOUSE_DEFULTE
            , WEREHOUSE_TYPE_ID, WEREHOUSE_COUNTRY_ID, WEREHOUSE_STATE_ID, WEREHOUSE_CITY_ID);
              return WEREHOUSE_NAME;
          }

        public int IfEmpty(int werehose_id)
        {
            var countitems = new Werehouses().IfWerehouse_Empty(werehose_id);
            alert("Can not be deleted ");
            return countitems;

        }

        private void alert(object status)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public JsonResult GetWerehouse()
        {
            var Data = new Werehouses().QueryReader("SELECT * FROM werehouse");


            return Json(Data);
        }
        
    }
}
