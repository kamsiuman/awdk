using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.Repository.Interface
{
    public interface IEventRepository
    {
        IEnumerable<EventVo> GetEventsByUserId(int userId);
        IEnumerable<EventVo> GetEventsByUserIdAndTimeRange(int userId, DateTime starTime, DateTime endTime);
        IEnumerable<EventVo> GetEventsByJobId(int jobId);
    }
}


