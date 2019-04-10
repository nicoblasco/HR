using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource.Repository;

namespace HumanResources.Business.Interface
{
    public interface ICountriesBusiness
    {
        List<Countries> GetAll();

        List<Countries> GetDuplicates(int id, string descripcion);

        Countries Get(int Id);

        void Save(Countries country);
    }
}
