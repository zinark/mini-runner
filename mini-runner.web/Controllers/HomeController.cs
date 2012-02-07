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

    }
}
