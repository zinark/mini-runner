using System;
using System.Web;
using System.Web.Mvc;
using mini_runner.web.Models;

namespace mini_runner.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new HomeViewModel ());
        }

        [HttpGet]
        public JsonResult Jobs ()
        {
            var jobs =  new HomeViewModel().Jobs;
            return Json(jobs, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Logs ()
        {
            var jobs =  new HomeViewModel().Logs;
            return Json(jobs, JsonRequestBehavior.AllowGet);
        }
    }
}
