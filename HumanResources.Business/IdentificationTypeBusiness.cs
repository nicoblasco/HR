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
    public class IdentificationTypeBusiness : IIdentificationTypeBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IdentificationTypeRepository repository;

        public IdentificationTypeBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new IdentificationTypeRepository(unitOfWork);
        }
        public IdentificationType Get(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<IdentificationType> GetAll()
        {
            List<IdentificationType> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public List<IdentificationType> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper()).ToList();
        }

        public void Save(IdentificationType model)
        {
            if (model.Id > 0)
                Update(model);
            else
                Create(model);
        }

        private void Create(IdentificationType view)
        {
            view.Enable = true;
            this.repository.Insert(view);
        }

        private void Update(IdentificationType view)
        {
            IdentificationType model = Get(view.Id);
            model.Name = view.Name;

            this.repository.Update(view);
        }
    }
}
