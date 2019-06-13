using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ken.Tutorial.Web.Controllers
{
    public class HomeController:Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this._logger=logger;
        }
         public IActionResult Index()
        {
            _logger.LogInformation("----\r\ninfo>>hello world\r\n----");
            _logger.LogError("----\r\nerror>>hello world\r\n----");
            _logger.LogWarning("----\r\nwarning>>hello world\r\n----");
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
