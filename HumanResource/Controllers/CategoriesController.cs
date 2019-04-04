using HumanResources.Business;
using HumanResources.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumanResource.Controllers
{
    public class CategoriesController : Controller
    {
        ICategoryBusiness _categoryBusiness;

        public CategoriesController(ICategoryBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }

        // GET: Categories
        public ActionResult Index()
        {
            
            return View();
        }
    }
}