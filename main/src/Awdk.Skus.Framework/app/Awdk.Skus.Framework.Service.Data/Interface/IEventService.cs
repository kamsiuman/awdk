using System;
using System.Collections.Generic;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.Service.Data.Interface
{
    public interface IEventService
    {
        IEnumerable<EventVo> GetEventsByUserId(int userId);
        IEnumerable<EventVo> GetEventsByUserIdAndTimeRange(int userId, DateTime starTime, DateTime endTime);
        IEnumerable<EventVo> GetEventsByJobId(int jobId);
        IEnumerable<EventVo> GetEventsByCurrentLoginUser(string currentUserAlias);
    }
}

