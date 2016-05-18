using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PlsDoMeNow.Models;

using Newtonsoft.Json;

namespace PlsDoMeNow.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            TodoListCategory[] myCats = TodoListCategory.GetCurrentUserCategories();
            JsonString jStr = JsonString.FromObject(myCats);
            return View(jStr);
        }
    }
}