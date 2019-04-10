using HumanResource.Repository;
using HumanResource.Repository.Infrastructure.Contract;
using HumanResources.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business
{
    public class DrivingCategoriesBusiness : IDrivingCategoriesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DrivingCategoriesRepository repository;

        public DrivingCategoriesBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new DrivingCategoriesRepository(unitOfWork);
        }
        public DrivingCategories Get(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<DrivingCategories> GetAll()
        {
            List<DrivingCategories> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public List<DrivingCategories> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Code.ToUpper() == descripcion.ToUpper()).ToList();
        }

        public void Save(DrivingCategories model)
        {
            if (model.Id > 0)
                Update(model);
            else
                Create(model);
        }

        private void Create(DrivingCategories view)
        {
            view.Enable = true;
            this.repository.Insert(view);
        }

        private void Update(DrivingCategories view)
        {
            DrivingCategories model = Get(view.Id);
            model.Code = view.Code;

            this.repository.Update(view);
        }
    }
}
