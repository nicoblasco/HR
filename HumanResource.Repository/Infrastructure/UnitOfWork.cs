using HumanResource.Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HumanResourceEntities _dbContext;

        public UnitOfWork()
        {
            _dbContext = new HumanResourceEntities();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }
}
