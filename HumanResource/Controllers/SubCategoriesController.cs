using HumanResource.Repository;
using HumanResources.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumanResource.Controllers
{
    public class SubCategoriesController : Controller
    {
        ISubCategoriesBusiness _subCategoriesBusiness;
        ICategoryBusiness _categoryBusiness;

        public SubCategoriesController(ISubCategoriesBusiness subCategoriesBusiness, ICategoryBusiness categoryBusiness)
        {
            this._subCategoriesBusiness = subCategoriesBusiness;
            this._categoryBusiness = categoryBusiness;
        }

        // GET: Categories
        public ActionResult Index()
        {
            ViewBag.listaCategorias = this._categoryBusiness.GetAllCategories();
            return View();
        }

        [HttpPost]
        public JsonResult Gets()
        {
            List<SubCategories> list = new List<SubCategories>();

            try
            {
                list = this._subCategoriesBusiness.GetAll();


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

            SubCategories model = new SubCategories();
            try
            {
                model = this._subCategoriesBusiness.Get(id);


                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { responseCode = "-10" });
            }
        }


        [HttpGet]
        public JsonResult GetDuplicates(int id, string descripcion, int categoriaId)
        {

            try
            {
                var result = this._subCategoriesBusiness.GetDuplicates(id, descripcion, categoriaId);

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

        public JsonResult Create(SubCategories model)
        {

            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._subCategoriesBusiness.Save(model);


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


        public JsonResult Edit(SubCategories model)
        {
            try
            {
                if (model == null)
                {
                    return Json(new { responseCode = "-10" });
                }

                this._subCategoriesBusiness.Save(model);

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


                SubCategories model = this._subCategoriesBusiness.Get(id);
                model.Enable = false;
                this._subCategoriesBusiness.Save(model);

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