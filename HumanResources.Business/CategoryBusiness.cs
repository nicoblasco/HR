using HumanResource.Domain;
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
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CategoryRepository repository;
        //private readonly IBaseRepository<Categories> _repository;

        //public CategoryBusiness(IBaseRepository<Categories> repository)
        //{
        //    _repository = repository;
        //}

        public CategoryBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new CategoryRepository(unitOfWork);
        }

        public List<Categories> GetAllCategories()
        {
            //HumanResourceEntities dbcontext = new HumanResourceEntities();

            List<Categories> list = this.repository.GetAll().Where(x=>x.Enable==true).ToList();    //dbcontext.Categories.Select(m => new CategoryDomainModel { Id = m.Id, Name = m.Name }).ToList();
            //list.Add(new CategoryDomainModel { Name = "Prueba", Id = 1 });
            //list.Add(new CategoryDomainModel { Name = "Prueba2", Id = 2 });

            return list;
        }


        public Categories GetCategory(int id)
        {
           return this.repository.GetAll(x => x.Id == id).FirstOrDefault();
        }

        public List<Categories> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper()).ToList();
                                                  
        }

        public string GetName(int Id)
        {
            return null;
        }

        public void Save(Categories category)
        {
            if (category.Id > 0)
                Update(category);
            else
                Create(category);


        }

        private void Create(Categories category)
        {
            category.Enable = true;
            this.repository.Insert(category);
        }

        private void Update(Categories category)
        {
            Categories model = GetCategory(category.Id);
            model.Name = category.Name;
            this.repository.Update(model);
        }
    }
}
