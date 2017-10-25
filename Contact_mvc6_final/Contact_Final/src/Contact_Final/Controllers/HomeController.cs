using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Contact_Final.Controllers
{
    ///Viewbag vs ViewData vs TempData 
    ///http://www.c-sharpcorner.com/blogs/viewdata-vs-viewbag-vs-tempdata-in-mvc1

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Informations = this.HttpContext.Request.Headers.Values;
            ViewBag.Controller = $"ControllerName => {ControllerContext.ActionDescriptor.ControllerName}, ActionName => {ControllerContext.ActionDescriptor.ActionName}";
            ViewData["Message"] = "Animus beate nihil nimias amicitiae superque pluribus illi (sed esse quam quibusdam superque unum securitatem.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
