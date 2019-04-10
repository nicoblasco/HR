using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface IRegionsBusiness
    {
        List<Regions> GetAll();

        List<Regions> GetDuplicates(int id, string descripcion);

        Regions Get(int Id);

        void Save(Regions regions);
    }
}
