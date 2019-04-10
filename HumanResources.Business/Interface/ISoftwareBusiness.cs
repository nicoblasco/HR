using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface ISoftwareBusiness
    {
        List<Software> GetAll();

        List<Software> GetDuplicates(int id, string descripcion);

        Software Get(int Id);

        void Save(Software country);
    }
}
