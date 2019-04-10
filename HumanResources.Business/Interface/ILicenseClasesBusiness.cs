using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface ILicenseClasesBusiness
    {
        List<LicenseClasses> GetAll();

        List<LicenseClasses> GetDuplicates(int id, string descripcion);

        LicenseClasses Get(int Id);

        void Save(LicenseClasses licenseClasses);
    }
}
