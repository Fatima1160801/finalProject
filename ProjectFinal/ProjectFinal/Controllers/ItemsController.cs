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
    public class ItemsController : Controller
    {
        private readonly ILogger<ItemsController> _logger;

        public ItemsController(ILogger<ItemsController> logger)
        {
            _logger = logger;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Index()
        {
            var Data = new Items().QueryReader("SELECT * FROM items");
            var Data1 = new Werehouses().QueryReader("SELECT * FROM werehouse");
            ViewBag.Items = Data.DefaultView;
            ViewBag.Werehouses = Data1.DefaultView;

            return View();
        }

        [HttpGet]
        public JsonResult GetItems(string ITEM_ID)
        {
            var Data = new Items().QueryReader("SELECT * FROM items");

            return Json(Data);
        }

        [HttpPost]
        public string AddItem(string Item_ID, string Item_NAME, string Werehouse_ID)
        {


            var newStudent = new Items().Insert_C_PASSPORT_TYPES_TB(Item_ID, Item_NAME , Werehouse_ID);
            return Item_NAME;
        }

        public string DeleteItem(string Item_ID)
        {
            var DELETED_ITEM_ID = new Items().DELETE_ITEM(Item_ID);


            return Item_ID;
        }

        public string UpdateStudent(int item_ID, string item_NAME)
        {

            var edit_item = new Items().UPDATE_ITEM(item_ID, item_NAME);
            return item_NAME;
        }

       
    }
}
