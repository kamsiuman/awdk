using System;
using System.Collections.Generic;
using System.Linq;
using Awdk.Skus.Framework.DataAccess.EF.Interface;
using Awdk.Skus.Framework.DataAccess.Repository.Interface;
using Awdk.Skus.Framework.DataAccess.Repository.Repository;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.Repository
{

    public class EventRepository : GenericRepository<EventVo, int>, IEventRepository
    {
        //private readonly ISkusDbContext _dbContext;
        //private readonly IDbContext _dbContext;

        public EventRepository(ISkusDbContext skusDbContext)
            : base(skusDbContext)
        {
            //_dbContext = skusDbContext;
        }

        public IEnumerable<EventVo> GetEventsByUserId(int userId)
        {
            return _dbContext.Set<EventVo>().Where(x => x.SkUserId.Equals(userId)).ToList<EventVo>();            
        }

        public IEnumerable<EventVo> GetEventsByUserIdAndTimeRange(int userId, DateTime starTime, DateTime endTime)
        {
            return _dbContext.Set<EventVo>()
                .Where(x => x.SkUserId.Equals(userId))
                .Where(x => x.EndTime > (starTime))
                .Where(x => x.StartTime < (endTime))
                .ToList<EventVo>();
        }

        public IEnumerable<EventVo> GetEventsByJobId(int jobId)
        {
            return _dbContext.Set<EventVo>().Where(x => x.JobId.Equals(jobId)).ToList<EventVo>();            
        }

    }
}
