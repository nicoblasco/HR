using HumanResource.Domain;
using HumanResource.Repository;
using HumanResources.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumanResource.Controllers
{
    public class CitiesController : Controller
    {
        ICitiesBusiness _citiesBusiness;
        IRegionsBusiness _regionsBusiness;
        ICountriesBusiness _countriesBusiness;

        public CitiesController(ICitiesBusiness citiesBusiness, IRegionsBusiness regionsBusiness, ICountriesBusiness countriesBusiness)
        {
            this._citiesBusiness = citiesBusiness;
            this._regionsBusiness = regionsBusiness;
            this._countriesBusiness = countriesBusiness;
        }

        // GET: Categories
        public ActionResult Index()
        {

            ViewBag.listaPaises = this._countriesBusiness.GetAll();
            ViewBag.listaRegiones = this._regionsBusiness.GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult Gets()
        {
            List<CitiesDomainModel> list = new List<CitiesDomainModel>();

            try
            {
                list = this._citiesBusiness.GetAll();


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

            Cities model = new Cities();
            try
            {
                model = this._citiesBusiness.GetCity(id);


                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { responseCode = "-10" });
            }
        }


        [HttpGet]
        public JsonResult GetDuplicates(int id, string descripcion, int regionId)
        {

            try
            {
                var result = this._citiesBusiness.GetDuplicates(id, descripcion, regionId);

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

        public JsonResult Create(Cities model)
        {

            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._citiesBusiness.Save(model);


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


        public JsonResult Edit(Cities model)
        {
            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._citiesBusiness.Save(model);

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


                Cities model = this._citiesBusiness.GetCity(id);
                model.Enable = false;
                this._citiesBusiness.Save(model);

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