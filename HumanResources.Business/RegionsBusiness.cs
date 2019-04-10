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
    public class RegionsBusiness : IRegionsBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly RegionsRepository repository;

        public RegionsBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new RegionsRepository(unitOfWork);
        }
        public Regions Get(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<Regions> GetAll()
        {
            List<Regions> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public List<Regions> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper()).ToList();
        }

        public void Save(Regions model)
        {
            if (model.Id > 0)
                Update(model);
            else
                Create(model);
        }

        private void Create(Regions view)
        {
            view.Enable = true;
            this.repository.Insert(view);
        }

        private void Update(Regions view)
        {
            Regions model = Get(view.Id);
            model.Name = view.Name;
            model.CountryId = view.CountryId;

            this.repository.Update(view);
        }
    }
}
