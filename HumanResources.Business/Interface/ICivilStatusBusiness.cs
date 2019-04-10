using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public  interface ICivilStatusBusiness
    {
        List<CivilStatus> GetAll();

        List<CivilStatus> GetDuplicates(int id, string descripcion);

        CivilStatus GetCivilStatus(int Id);

        void Save(CivilStatus civilStatus);
    }
}
