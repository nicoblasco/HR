using HumanResource.Repository.Infrastructure;
using HumanResource.Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Repository
{
    public class CategoryRepository:BaseRepository<Categories>
    {
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    }
}
