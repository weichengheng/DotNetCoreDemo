using System;
using Microsoft.AspNetCore.Mvc;
using Ken.Tutorial.Web.Models;

namespace Ken.Tutorial.Web.Controllers
{
    public class ParamsMappingTestController : Controller
    {
        public IActionResult GetId(int id)
        {
            return Content($"params test , id:{id}");
        }

        public IActionResult GetArray(string[] id)
        {
            return Content($"params test , ids:{string.Join("_", id)}");
        }

        public IActionResult GetPerson(Person person)
        {
            return Json(new { msg = "getperson test", Data = person });
        }

        public IActionResult GetPersonJson([FromBody]Person person)
        {
            return Json(new { msg = "getperson test", Data = person });
        }

        public IActionResult GetByHand()
        {
            return Json(new
            {
                Id = RouteData.Values["id"],//从路由中取数据
                Name = Request.Query["name"],//从url中取数据
                Name2 = Request.Form["name"],//从form表单中取数据
            });
        }
    }
}
