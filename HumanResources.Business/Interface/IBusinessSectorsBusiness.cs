using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface IBusinessSectorsBusiness
    {
        List<BusinessSectors> GetAll();

        List<BusinessSectors> GetDuplicates(int id, string descripcion);

        BusinessSectors GetBusinessSectors(int Id);

        void Save(BusinessSectors  businessSectors);
    }
}
