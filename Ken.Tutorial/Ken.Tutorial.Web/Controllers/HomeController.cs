using System;
using Microsoft.AspNetCore.Mvc;

namespace Ken.Tutorial.Web.Controllers
{
    public class HomeController:Controller
    {
         public IActionResult Index()
        {
            return Content(DateTime.Now.ToString()+ "\tHello World!");
        }

        public IActionResult Time()
        {
            ViewBag.ServerTime=DateTime.Now;
            return View();
        }
    }
}
