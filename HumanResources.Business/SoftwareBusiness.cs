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
    public class SoftwareBusiness : ISoftwareBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SoftwareRepository repository;

        public SoftwareBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new SoftwareRepository(unitOfWork);
        }
        public Software Get(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<Software> GetAll()
        {
            List<Software> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public List<Software> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper()).ToList();
        }

        public void Save(Software model)
        {
            if (model.Id > 0)
                Update(model);
            else
                Create(model);
        }

        private void Create(Software view)
        {
            view.Enable = true;
            this.repository.Insert(view);
        }

        private void Update(Software view)
        {
            Software model = Get(view.Id);
            model.Name = view.Name;

            this.repository.Update(view);
        }
    }
}
