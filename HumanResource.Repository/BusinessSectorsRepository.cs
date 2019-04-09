using HumanResource.Repository.Infrastructure;
using HumanResource.Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Repository
{
    public class BusinessSectorsRepository : BaseRepository<BusinessSectors>
    {
        public BusinessSectorsRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
