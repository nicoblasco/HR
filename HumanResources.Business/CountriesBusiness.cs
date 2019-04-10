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
    public class CountriesBusiness : ICountriesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CountriesRepository repository;

        public CountriesBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new CountriesRepository(unitOfWork);
        }

        public Countries Get(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<Countries> GetAll()
        {
            List<Countries> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public List<Countries> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper()).ToList();
        }

        public void Save(Countries country)
        {
            if (country.Id > 0)
                Update(country);
            else
                Create(country);
        }

        private void Create(Countries country)
        {
            country.Enable = true;
            this.repository.Insert(country);
        }

        private void Update(Countries country)
        {
            Countries model = Get(country.Id);
            model.Name = country.Name;

            this.repository.Update(model);
        }
    }
}
