using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface IStudiesLevelBusiness
    {
        List<StudiesLevel> GetAll();

        List<StudiesLevel> GetDuplicates(int id, string descripcion);

        StudiesLevel Get(int Id);

        void Save(StudiesLevel studiesLevel);
    }
}
