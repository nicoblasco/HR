using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource.Domain;
using HumanResource.Repository;
using HumanResource.Repository.Infrastructure.Contract;
using HumanResources.Business.Interface;

namespace HumanResources.Business
{
    public class CitiesBusiness : ICitiesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CitiesRepository repository;

        public CitiesBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new CitiesRepository(unitOfWork);
        }

        public List<CitiesDomainModel> GetAll()
        {
            List<Cities> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            List<CitiesDomainModel> list2 = new List<CitiesDomainModel>();


            foreach (var item in list)
            {
                CitiesDomainModel city  = new CitiesDomainModel
                {
                    Country = item.Regions.Countries.Name,
                    Region = item.Regions.Name,
                    Id = item.Id,
                    Name = item.Name

                };
                list2.Add(city);

            }


            return list2;
        }

        public Cities GetCity(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<Cities> GetDuplicates(int id, string descripcion, int regionId)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper() && x.RegionId == regionId).ToList();
        }

        public void Save(Cities model)
        {
            if (model.Id > 0)
                Update(model);
            else
                Create(model);
        }


        private void Create(Cities view)
        {
            view.Enable = true;
            this.repository.Insert(view);
        }

        private void Update(Cities view)
        {
            Cities model = GetCity(view.Id);
            model.Name = view.Name;

            this.repository.Update(view);
        }
    }
}
