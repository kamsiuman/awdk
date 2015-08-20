using System;
using System.Linq;
using Awdk.Skus.Framework.DataAccess.EF.Interface;
using Awdk.Skus.Framework.DataAccess.Repository.Interface;
using Awdk.Skus.Framework.DataAccess.Repository.Repository;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.Repository
{
    public class SkUserRepository : GenericRepository<SkUserVo, int>, ISkUserRepository
    {

        public SkUserRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public bool Authenticate(string userId, string password)
        {
            return true;
        }

        public SkUserVo GetUserByToken(string key)
        {
            throw new NotImplementedException();
        }

        public SkUserVo SelectByUserId(string userId)
        {
            return _dbContext.Set<SkUserVo>().FirstOrDefault(x => x.SkUserId.Equals(userId));   
        }

        public SkUserVo GetUserVoFromWorkspaceId(string userId)
        {
            return _dbContext.Set<SkUserVo>().FirstOrDefault(x => x.SkUserId.Equals(userId));
        }


    }
}
