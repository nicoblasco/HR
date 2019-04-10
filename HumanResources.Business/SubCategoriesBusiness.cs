using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource.Repository;
using HumanResource.Repository.Infrastructure.Contract;
using HumanResources.Business.Interface;

namespace HumanResources.Business
{
    public class SubCategoriesBusiness : ISubCategoriesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SubCategoriesRepository repository;

        public SubCategoriesBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new SubCategoriesRepository(unitOfWork);
        }
        public SubCategories Get(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<SubCategories> GetAll()
        {
            List<SubCategories> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public List<SubCategories> GetDuplicates(int id, string descripcion, int categoriaId)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper() &&  x.CategoryId == categoriaId).ToList();
        }

        public void Save(SubCategories model)
        {
            if (model.Id > 0)
                Update(model);
            else
                Create(model);
        }

        private void Create(SubCategories view)
        {
            view.Enable = true;
            this.repository.Insert(view);
        }

        private void Update(SubCategories view)
        {
            SubCategories model = Get(view.Id);
            model.Name = view.Name;
            model.CategoryId = view.CategoryId;

            this.repository.Update(view);
        }
    }
}
