using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource.Repository.Infrastructure;
using HumanResource.Repository.Infrastructure.Contract;

namespace HumanResource.Repository
{
    public class CountriesRepository : BaseRepository<Countries>
    {
        public CountriesRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
