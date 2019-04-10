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
    public class StudiesLevelBusiness : IStudiesLevelBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly StudiesLevelRepository repository;

        public StudiesLevelBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new StudiesLevelRepository(unitOfWork);
        }
        public StudiesLevel Get(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<StudiesLevel> GetAll()
        {
            List<StudiesLevel> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public List<StudiesLevel> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper()).ToList();
        }

        public void Save(StudiesLevel model)
        {
            if (model.Id > 0)
                Update(model);
            else
                Create(model);
        }

        private void Create(StudiesLevel view)
        {
            view.Enable = true;
            this.repository.Insert(view);
        }

        private void Update(StudiesLevel view)
        {
            StudiesLevel model = Get(view.Id);
            model.Name = view.Name;
            model.Level = view.Level;

            this.repository.Update(view);
        }
    }
}
