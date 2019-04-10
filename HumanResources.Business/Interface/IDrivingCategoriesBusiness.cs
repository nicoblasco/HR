using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface IDrivingCategoriesBusiness
    {
        List<DrivingCategories> GetAll();

        List<DrivingCategories> GetDuplicates(int id, string descripcion);

        DrivingCategories Get(int Id);

        void Save(DrivingCategories drivingCategories);
    }
}
