using HumanResource.Repository;
using HumanResources.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumanResource.Controllers
{
    public class DrivingCategoriesController : Controller
    {
        IDrivingCategoriesBusiness _drivingCategoriesBusiness;

        public DrivingCategoriesController(IDrivingCategoriesBusiness drivingCategoriesBusiness)
        {
            this._drivingCategoriesBusiness = drivingCategoriesBusiness;
        }

        // GET: Categories
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult Gets()
        {
            List<DrivingCategories> list = new List<DrivingCategories>();

            try
            {
                list = this._drivingCategoriesBusiness.GetAll();


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

            DrivingCategories model = new DrivingCategories();
            try
            {
                model = this._drivingCategoriesBusiness.Get(id);


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
                var result = this._drivingCategoriesBusiness.GetDuplicates(id, descripcion);

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

        public JsonResult Create(DrivingCategories model)
        {

            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._drivingCategoriesBusiness.Save(model);


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


        public JsonResult Edit(DrivingCategories model)
        {
            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._drivingCategoriesBusiness.Save(model);

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


                DrivingCategories model = this._drivingCategoriesBusiness.Get(id);
                model.Enable = false;
                this._drivingCategoriesBusiness.Save(model);

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