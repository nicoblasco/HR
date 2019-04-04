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
        private readonly IBaseRepository<Categories> _repository;

        public List<Categories> GetAllCategories()
        {
            //HumanResourceEntities dbcontext = new HumanResourceEntities();

            List<Categories> list = this._repository.GetAll().ToList();    //dbcontext.Categories.Select(m => new CategoryDomainModel { Id = m.Id, Name = m.Name }).ToList();
            //list.Add(new CategoryDomainModel { Name = "Prueba", Id = 1 });
            //list.Add(new CategoryDomainModel { Name = "Prueba2", Id = 2 });

            return list;
        }

        public string GetName(int Id)
        {
            return null;
        }
    }
}
