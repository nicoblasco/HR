using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface ILanguagesBusiness
    {
        List<Languages> GetAll();

        List<Languages> GetDuplicates(int id, string descripcion);

        Languages Get(int Id);

        void Save(Languages  languages);
    }
}
