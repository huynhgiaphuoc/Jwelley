using Jewelly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
namespace Jwelley.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model1 = new Join().SelectHome().ToList();
            var model2 = new Join().SelectHome1().ToList();
            var model3 = new Join().SelectHome2().ToList();
            var model4 = new Join().SelectHome3().ToList();
            var model5 = new Join().SelectHome4().ToList();

            dynamic models1 = new ExpandoObject();
            models1.Home1 = model1;
            models1.Home2 = model2;
            models1.Home3 = model3;
            models1.Home4 = model4;
            models1.Homef = model5;

            return View(models1);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Policy()
        {
            return View();
        }

        public ActionResult Rules()
        {
            return View();
        }
    }
}