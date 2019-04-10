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
    public class LanguageLevelBusiness : ILanguageLevelBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly LanguageLevelRepository repository;

        public LanguageLevelBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new LanguageLevelRepository(unitOfWork);
        }
        public List<LanguageLevel> GetAll()
        {
            List<LanguageLevel> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public List<LanguageLevel> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper()).ToList();
        }

        public LanguageLevel GetLanguageLevel(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public void Save(LanguageLevel model)
        {
            if (model.Id > 0)
                Update(model);
            else
                Create(model);
        }

        private void Create(LanguageLevel view)
        {
            view.Enable = true;
            this.repository.Insert(view);
        }

        private void Update(LanguageLevel view)
        {
            LanguageLevel model = GetLanguageLevel(view.Id);
            model.Name = view.Name;

            this.repository.Update(view);
        }
    }
}
