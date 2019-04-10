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
    public class LicenseClassesBusiness : ILicenseClasesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly LicenseClasesRepository repository;

        public LicenseClassesBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new LicenseClasesRepository(unitOfWork);
        }
        public LicenseClasses Get(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<LicenseClasses> GetAll()
        {
            List<LicenseClasses> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public List<LicenseClasses> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Codigo.ToUpper() == descripcion.ToUpper()).ToList();
        }

        public void Save(LicenseClasses model)
        {
            if (model.Id > 0)
                Update(model);
            else
                Create(model);
        }

        private void Create(LicenseClasses view)
        {
            view.Enable = true;
            this.repository.Insert(view);
        }

        private void Update(LicenseClasses view)
        {
            LicenseClasses model = Get(view.Id);
            model.Descripcion = view.Descripcion;
            model.Codigo = view.Codigo;

            this.repository.Update(view);
        }
    }
}
