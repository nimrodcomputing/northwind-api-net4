using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Northwind.Data;

namespace Northwind.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.ConnectionString = ConfigurationManager.ConnectionStrings[NorthwindDb.ConnectionString];

            return View();
        }
    }
}
