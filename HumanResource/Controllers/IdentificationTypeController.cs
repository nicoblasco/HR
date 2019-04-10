using HumanResource.Repository;
using HumanResources.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumanResource.Controllers
{
    public class IdentificationTypeController : Controller
    {
        IIdentificationTypeBusiness _identificationTypeBusiness;

        public IdentificationTypeController(IIdentificationTypeBusiness identificationTypeBusiness)
        {
            this._identificationTypeBusiness = identificationTypeBusiness;
        }

        // GET: Categories
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult Gets()
        {
            List<IdentificationType> list = new List<IdentificationType>();

            try
            {
                list = this._identificationTypeBusiness.GetAll();


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

            IdentificationType model = new IdentificationType();
            try
            {
                model = this._identificationTypeBusiness.Get(id);


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
                var result = this._identificationTypeBusiness.GetDuplicates(id, descripcion);

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

        public JsonResult Create(IdentificationType model)
        {

            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._identificationTypeBusiness.Save(model);


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


        public JsonResult Edit(IdentificationType model)
        {
            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._identificationTypeBusiness.Save(model);

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


                IdentificationType model = this._identificationTypeBusiness.Get(id);
                model.Enable = false;
                this._identificationTypeBusiness.Save(model);

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