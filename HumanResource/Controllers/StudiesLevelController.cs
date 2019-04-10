using HumanResource.Repository;
using HumanResources.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumanResource.Controllers
{
    public class StudiesLevelController : Controller
    {
        IStudiesLevelBusiness _studiesLevelBusiness;

        public StudiesLevelController(IStudiesLevelBusiness studiesLevelBusiness )
        {
            this._studiesLevelBusiness = studiesLevelBusiness;
        }

        // GET: Categories
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult Gets()
        {
            List<StudiesLevel> list = new List<StudiesLevel>();

            try
            {
                list = this._studiesLevelBusiness.GetAll();


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

            StudiesLevel model = new StudiesLevel();
            try
            {
                model = this._studiesLevelBusiness.Get(id);


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
                var result = this._studiesLevelBusiness.GetDuplicates(id, descripcion);

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

        public JsonResult Create(StudiesLevel model)
        {

            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._studiesLevelBusiness.Save(model);


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


        public JsonResult Edit(StudiesLevel model)
        {
            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._studiesLevelBusiness.Save(model);

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


                StudiesLevel model = this._studiesLevelBusiness.Get(id);
                model.Enable = false;
                this._studiesLevelBusiness.Save(model);

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