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
    public class CivilStatusBusiness : ICivilStatusBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CivilStatusRepository repository;

        public CivilStatusBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new CivilStatusRepository(unitOfWork);
        }

        public List<CivilStatus> GetAll()
        {
            List<CivilStatus> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public CivilStatus GetCivilStatus(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<CivilStatus> GetDuplicates(int id, string descripcion)
        {
            List<CivilStatus> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public void Save(CivilStatus civilStatus)
        {
            if (civilStatus.Id > 0)
                Update(civilStatus);
            else
                Create(civilStatus);
        }

        private void Create(CivilStatus civilStatus)
        {
            civilStatus.Enable = true;
            this.repository.Insert(civilStatus);
        }

        private void Update(CivilStatus civilStatus)
        {
            CivilStatus model = GetCivilStatus(civilStatus.Id);
            model.Name = civilStatus.Name;

            this.repository.Update(model);
        }
    }
}
