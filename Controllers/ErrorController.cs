using aspnetmvc2.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvc2.Controllers
{
    [Localization]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }
    }
}