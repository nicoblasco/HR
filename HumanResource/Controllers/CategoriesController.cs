using HumanResource.Repository;
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
           this._categoryBusiness = categoryBusiness;
        }

        // GET: Categories
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public JsonResult Gets()
        {
            List<Categories> list = new List<Categories>();
            
            try
            {
                list = this._categoryBusiness.GetAllCategories();


                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { responseCode = "-10" });

            }
        }


        [HttpPost]
        public JsonResult Get(int id)
        {

            Categories model = new Categories();
            try
            {
                model = this._categoryBusiness.GetCategory(id);


                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { responseCode = "-10" });
            }
        }


        [HttpGet]
        public JsonResult GetDuplicates(int id, string descripcion)
        {

            try
            {
                var result = this._categoryBusiness.GetDuplicates(id, descripcion);

                var responseObject = new
                {
                    responseCode = result.Count()
                };

                return Json(responseObject, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                // return Json(new { responseCode = "-10" });
                throw;
            }
        }

        public JsonResult Create(Categories model)
        {

            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._categoryBusiness.Save(model);


                var responseObject = new
                {
                    responseCode = 0
                };

                return Json(responseObject);
            }
            catch (Exception)
            {

                return Json(new { responseCode = "-10" });
            }

        }


        public JsonResult Edit(Categories model)
        {
            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._categoryBusiness.Save(model);

                var responseObject = new
                {
                    responseCode = 0
                };

                return Json(responseObject);
            }
            catch (Exception)
            {

                return Json(new { responseCode = "-10" });
            }

        }

        public JsonResult Delete(int id)
        {
            try
            {

                if (id == 0)
                {
                    return Json(new { responseCode = "-10" });
                }


                Categories model = this._categoryBusiness.GetCategory(id);
                model.Enable = false;
                this._categoryBusiness.Save(model);

                var responseObject = new
                {
                    responseCode = 0
                };
                return Json(responseObject);
            }
            catch (Exception)
            {
                return Json(new { responseCode = "-10" });

            }
            


        }

    }
}