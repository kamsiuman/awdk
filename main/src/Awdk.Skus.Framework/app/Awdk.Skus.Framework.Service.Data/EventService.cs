using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awdk.Skus.Framework.DataAccess.Repository;
using Awdk.Skus.Framework.DataAccess.Repository.Interface;
using Awdk.Skus.Framework.Entity.ValueObject;
using Awdk.Skus.Framework.Service.Data.Interface;

namespace Awdk.Skus.Framework.Service.Data
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        #region public
        public IEnumerable<EventVo> GetEventsByUserId(int userId)
        {
            return eventRepository.GetEventsByUserId(userId);
        }

        public IEnumerable<EventVo> GetEventsByUserIdAndTimeRange(int userId, DateTime starTime, DateTime endTime)
        {
            return eventRepository.GetEventsByUserIdAndTimeRange(userId, starTime, endTime);
        }

        public IEnumerable<EventVo> GetEventsByJobId(int jobId)
        {
            return eventRepository.GetEventsByJobId(jobId);
        }

        public IEnumerable<EventVo> GetEventsByCurrentLoginUser(string currentUserAlias)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region private functions



        #endregion



    }
}
