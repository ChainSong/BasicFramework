using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicFramework.WebAPI.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index(string OrderKey)
        {
            ViewBag.Message = "hahahahaha";
            return View();
        }

      
    }
}
