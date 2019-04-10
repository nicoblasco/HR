using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface IIdentificationTypeBusiness
    {
        List<IdentificationType> GetAll();

        List<IdentificationType> GetDuplicates(int id, string descripcion);

        IdentificationType Get(int Id);

        void Save(IdentificationType identificationType);
    }
}
