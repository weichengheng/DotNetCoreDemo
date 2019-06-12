using System;
using Microsoft.AspNetCore.Mvc;

namespace Ken.Tutorial.Web.Controllers
{
    public class HomeController:Controller
    {
         public IActionResult Index()
        {
            //返回文本内容
            //return Content(DateTime.Now.ToString()+ "\tHello World!");

            //返回视图
            ViewBag.Title="Home--Index";
            ViewBag.Msg="hello world ! ! ! ";
            return View();
        }

        public IActionResult Time()
        {
            //返回视图
            ViewBag.ServerTime=DateTime.Now;
            return View();
        }
    }
}
