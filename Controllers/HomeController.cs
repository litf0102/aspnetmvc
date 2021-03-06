﻿using aspnetmvc2.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvc2.Controllers
{
    //国際化対応
    [Localization]
    //アクション追跡対応
    [ActionAuthorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = Resources.Global.Content;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public JsonResult ListUser(String term)
        //{
        //    var users = new String[] { "abc","123","def"};

        //    return Json(users,JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult Autocomplete(string term)
        //{
        //    var items = new[] { "Apple", "Pear", "Banana", "Pineapple", "Peach" };
        //    var filteredItems = items.Where(
        //        item => item.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0
        //        );
        //    return Json(filteredItems, JsonRequestBehavior.AllowGet);
        //}

        ////
        //// POST: /Home/Search
        //[AllowAnonymous]
        //public ActionResult Search(Models.SearchViewModel model, string returnUrl)
        //{
        //    ViewBag.Title = "Search Result";
        //    ViewBag.Message = "Your search result page."+"("+ "Conditon1: " + model.complete + " " + "Conditon2: " + model.somevalue + ")";
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}

        ////
        //// POST: /Home/Search2
        //[AllowAnonymous]
        //[HttpPost]
        //public JsonResult Search2(object conditions = null)
        //{
        //    string complete = ((string[])conditions)[0];
        //    string somevalue = ((string[])conditions)[1];
        //    String result = "Ajax OK.";
        //    //ViewBag.ReturnUrl = returnUrl;
        //    return Json(result);
        //}
    }
}