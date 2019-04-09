using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResource.Repository.Infrastructure;
using HumanResource.Repository.Infrastructure.Contract;

namespace HumanResource.Repository
{
    public class KnowledgeRepository : BaseRepository<Knowledge>
    {
        public KnowledgeRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
