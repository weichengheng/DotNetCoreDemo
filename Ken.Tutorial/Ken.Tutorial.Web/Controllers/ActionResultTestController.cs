using System;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Ken.Tutorial.Web.Controllers
{
    public class ActionResultTestController:Controller
    {
        //action result 测试
        public IActionResult ContentTest()
        {
            return Content("content result test by nfym");            
        }

        public IActionResult JsonResultTest()
        {
            return Json(new {state="1",msg="jsonresult test",by="nfym"});
        }

        public IActionResult FileTest()
        {
            var bytes=Encoding.Default.GetBytes("fileresult test by nfym!!!");
            return File(bytes,"application/text","filetest.txt");
        }

        public IActionResult RedirectTest()
        {
            return Redirect("http://www.baidu.com");//重定向到url            
        }

        public IActionResult Redirect2ActionTest()
        {
            return RedirectToAction("JsonResultTest");//重定向到action
        }

        public IActionResult Redirect2RouteTest()
        {
            return RedirectToRoute(new {Controller="home",Action="Time"});//重定向到路由
        }
    }
}
