using System;
using System.Collections.Generic;
using System.Linq;
using Awdk.Skus.Framework.DataAccess.EF;
using Awdk.Skus.Framework.DataAccess.EF.Interface;
using Awdk.Skus.Framework.Entity.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Awdk.Skus.Framework.DataAccess.Repository.Test
{
    [TestClass]
    public class EventRepositoryTest
    {
        #region Fields
        private EventRepository eventRepository;
        private ISkusDbContext skusDbContext;
        #endregion

        [TestInitialize]
        public void SetUp()
        {
            skusDbContext = new SkusDbContext();
            eventRepository = new EventRepository(skusDbContext);
        }

        #region Tests

        [TestMethod]
        public void GetSingleSkUserWithEvents_Should_ReturnEvents()
        {
            var events = eventRepository.GetById(3);
            Assert.IsTrue(events.EventName == "Event_3");

        }

        [TestMethod]
        public void GetEventsByUserId_Should_work()
        {
            var events = eventRepository.GetEventsByUserId(2);
            Assert.IsTrue(events.Count() == 5);

        }

        [TestMethod]
        public void GetEventsByUserIdAndTimeRange_Should_work()
        {
            var startTime = new DateTime(2015, 2, 2);
            var endTime = new DateTime(2015, 2, 3);

            var events = eventRepository.GetEventsByUserIdAndTimeRange(2, startTime, endTime);
            Assert.IsTrue(events.Count() == 2);

        }

        [TestMethod]
        public void GetEventsByJobId_Should_work()
        {
            var events = eventRepository.GetEventsByJobId(1);
            Assert.IsTrue(events.Count() == 2);

        }


        #endregion


        #region Helper Methods
        private SkUserVo GetNewSkUserForTest()
        {
            var events = new List<EventVo>();
            events.Add(GetNewEventForTest());
            events.Add(GetNewEventForTest());
            return new SkUserVo()
            {
                SkUserId = 1,
                Alias = "awong5",
                RoleTypeId = 1,
                Events = events,
            };
        }

        private EventVo GetNewEventForTest()
        {
            return new EventVo()
            {
                EventId= 1,
                EventName = "EventNameA",
                //ProjectId = 1,
                //OpenHoleInMeter = 10.0,
                //CasingInMeter = 10.0,
                //DepthInMeter = 10.0,
                //OwnerId = 1,
                //refId = Guid.NewGuid().ToString(),
                //Slug  = "S1",
                //DesignTypeId = 1,
                //CompletePercentage = 0.0,
                CreatedBy = "alex",
                CreatedDate = DateTime.UtcNow,
                LastModifiedBy = "alex",
                LastModifiedDate = DateTime.UtcNow,
            };
        }

        #endregion


    }
}
