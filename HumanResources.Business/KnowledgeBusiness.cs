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
    public class KnowledgeBusiness : IKnowledgeBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly KnowledgeRepository repository;

        public KnowledgeBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new KnowledgeRepository(unitOfWork);
        }
        public List<Knowledge> GetAll()
        {
            List<Knowledge> list = this.repository.GetAll().Where(x => x.Enable == true).ToList();
            return list;
        }

        public List<Knowledge> GetDuplicates(int id, string descripcion)
        {
            return this.repository.GetAll(x => x.Id != id && x.Name.ToUpper() == descripcion.ToUpper()).ToList();
        }

        public Knowledge GetKnowledge(int Id)
        {
            return this.repository.GetAll(x => x.Id == Id).FirstOrDefault();
        }

        public void Save(Knowledge model)
        {
            if (model.Id > 0)
                Update(model);
            else
                Create(model);
        }

        private void Create(Knowledge view)
        {
            view.Enable = true;
            this.repository.Insert(view);
        }

        private void Update(Knowledge view)
        {
            Knowledge model = GetKnowledge(view.Id);
            model.Name = view.Name;

            this.repository.Update(view);
        }
    }
}
