using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource.Repository.Infrastructure;
using HumanResource.Repository.Infrastructure.Contract;

namespace HumanResource.Repository
{
    public class RegionsRepository : BaseRepository<Regions>
    {
        public RegionsRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
