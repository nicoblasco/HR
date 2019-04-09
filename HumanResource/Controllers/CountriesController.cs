using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumanResource.Controllers
{
    public class CountriesController : Controller
    {
        // GET: Countries
        public ActionResult Index()
        {
            return View();
        }
    }
}