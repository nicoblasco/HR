using HumanResource.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Business.Interface
{
    public interface ISubCategoriesBusiness
    {
        List<SubCategories> GetAll();

        List<SubCategories> GetDuplicates(int id, string descripcion, int categoriaId);

        SubCategories Get(int Id);

        void Save(SubCategories regions);
    }
}
