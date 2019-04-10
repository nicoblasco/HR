using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface IKnowledgeBusiness
    {
        List<Knowledge> GetAll();

        List<Knowledge> GetDuplicates(int id, string descripcion);

        Knowledge GetKnowledge(int Id);

        void Save(Knowledge knowledge);
    }
}
