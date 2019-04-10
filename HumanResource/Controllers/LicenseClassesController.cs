using HumanResource.Repository;
using HumanResources.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumanResource.Controllers
{
    public class LicenseClassesController : Controller
    {
        ILicenseClasesBusiness _licenseClasesBusiness;

        public LicenseClassesController(ILicenseClasesBusiness licenseClasesBusiness )
        {
            this._licenseClasesBusiness = licenseClasesBusiness;
        }

        // GET: Categories
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult Gets()
        {
            List<LicenseClasses> list = new List<LicenseClasses>();

            try
            {
                list = this._licenseClasesBusiness.GetAll();


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

            LicenseClasses model = new LicenseClasses();
            try
            {
                model = this._licenseClasesBusiness.Get(id);


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
                var result = this._licenseClasesBusiness.GetDuplicates(id, descripcion);

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

        public JsonResult Create(LicenseClasses model)
        {

            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._licenseClasesBusiness.Save(model);


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


        public JsonResult Edit(LicenseClasses model)
        {
            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._licenseClasesBusiness.Save(model);

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


                LicenseClasses model = this._licenseClasesBusiness.Get(id);
                model.Enable = false;
                this._licenseClasesBusiness.Save(model);

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