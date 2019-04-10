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
    public class BusinessSectorsBusiness : IBusinessSectorsBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly BusinessSectorsRepository repository;


        public BusinessSectorsBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new BusinessSectorsRepository(unitOfWork);
        }

        public List<BusinessSectors> GetAll()
        {
            List<BusinessSectors> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public BusinessSectors GetBusinessSectors(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<BusinessSectors> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper()).ToList();
        }

        public void Save(BusinessSectors businessSectors)
        {
            if (businessSectors.Id > 0)
                Update(businessSectors);
            else
                Create(businessSectors);
        }

        private void Create(BusinessSectors businessSectors)
        {
            businessSectors.Enable = true;
            this.repository.Insert(businessSectors);
        }

        private void Update(BusinessSectors businessSectors)
        {
            BusinessSectors model = GetBusinessSectors(businessSectors.Id);
            model.Name = businessSectors.Name;
            
            this.repository.Update(model);
        }
    }
}
