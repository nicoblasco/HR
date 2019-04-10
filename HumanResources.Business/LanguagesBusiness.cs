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
    public class LanguagesBusiness : ILanguagesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly LanguagesRepository repository;

        public LanguagesBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new LanguagesRepository(unitOfWork);
        }
        public Languages Get(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public List<Languages> GetAll()
        {
            List<Languages> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public List<Languages> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper()).ToList();
        }

        public void Save(Languages model)
        {
            if (model.Id > 0)
                Update(model);
            else
                Create(model);
        }

        private void Create(Languages view)
        {
            view.Enable = true;
            this.repository.Insert(view);
        }

        private void Update(Languages view)
        {
            Languages model = Get(view.Id);
            model.Name = view.Name;

            this.repository.Update(view);
        }
    }
}
