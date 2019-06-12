using System;
using Microsoft.AspNetCore.Mvc;
using Ken.Tutorial.Web.Repositories;
using Ken.Tutorial.Web.Models.Entity;

namespace Ken.Tutorial.Web.Controllers
{
    public class EfCoreTestController:Controller
     {
        public BillDetailSync2SapLogRepository Repository {get;}

        public EfCoreTestController(BillDetailSync2SapLogRepository repository)
        {
            this.Repository=repository;
        }

        public IActionResult Test()
        {
            return Json(new {msg="test"});
        }


        public IActionResult Add(BillDetailSync2SapLogEntity model)
        {
            var doret=Repository.Add(model);
            return Json(new {msg=doret>0?"success":"failed",data=model});
        }

        public IActionResult Del(int id)
        {
            var doret=Repository.Del(id);
            return Json(new {msg=doret>0?"success":"failed"});
        }

        public IActionResult Update(BillDetailSync2SapLogEntity model)
        {
            var doret=Repository.Update(model);
            return Json(new {msg=doret>0?"success":"failed",data=model});
        }

        public IActionResult GetById(int id)
        {
            var ret=Repository.GetById(id);
            return Json(new {data=ret});
        }

        public IActionResult GetList(int pageIndex,int pageSize)
        {
            var ret=Repository.GetList(pageSize,pageIndex);
            return Json(new {data=ret});
        }
    }
}
