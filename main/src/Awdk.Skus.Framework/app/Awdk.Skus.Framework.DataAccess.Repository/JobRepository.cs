using System;
using Awdk.Skus.Framework.DataAccess.EF.Interface;
using Awdk.Skus.Framework.DataAccess.Repository.Repository;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.Repository
{
    public class JobRepository : GenericRepository<JobVo, int>
    {

        public JobRepository(ISkusDbContext dbContext)
            : base(dbContext)
        {
        }

        public bool Authenticate(string userId, string password)
        {
            throw new NotImplementedException();
        }
    }
}
