using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource.Domain;
using HumanResource.Repository;

namespace HumanResources.Business.Interface
{
    public interface ICitiesBusiness
    {
      //  List<Cities> GetAll();

        List<CitiesDomainModel> GetAll();

        List<Cities> GetDuplicates(int id, string descripcion, int regionId);

        Cities GetCity(int Id);

        void Save(Cities city);
    }
}
