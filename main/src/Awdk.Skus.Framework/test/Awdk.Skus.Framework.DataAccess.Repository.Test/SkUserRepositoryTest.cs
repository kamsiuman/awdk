using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Awdk.Skus.Framework.DataAccess.EF;
using Awdk.Skus.Framework.DataAccess.EF.Interface;
using Awdk.Skus.Framework.Entity.ValueObject;
using Awdk.Skus.Framework.DataAccess.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Awdk.Skus.Framework.DataAccess.Repository.Test
{
    [TestClass]
    public class SkUserRepositoryTest
    {
        #region Fields
        private SkUserRepository skUserRepository;
        private IDbContext skusDbContext;
        #endregion

        [TestInitialize]
        public void SetUp()
        {
            skusDbContext = new SkusDbContext();
            skUserRepository = new SkUserRepository(skusDbContext);
        }

        #region Tests

        [TestMethod]
        public void GetSingleSkUserWithEvents_Should_ReturnEvents()
        {
            var skUser = skUserRepository.GetById(1);
            // events = skUser.Events;
            Assert.IsTrue(skUser.RoleTypeId == 1);

        }


        //[TestMethod]
        //public void CreateProject_Should_Succeed()
        //{
        //    var Project = GetNewProjectForTest();
            
        //    //int projectNumberBefore = taiJiDBContext.Projects.Count();
        //    int projectNumberBefore = taiJiDBContext.Set<ProjectVO>().Count();
        //    mProjectRepository.Insert(Project);
        //    int projectNumberAfter = taiJiDBContext.Set<ProjectVO>().Count();

        //    Assert.IsTrue(projectNumberAfter - projectNumberBefore == 1);
        //}

        //[TestMethod]
        //public void CreateProjectWithSection_Should_PersistBothProjectAndSection()
        //{
        //    var Project = GetNewProjectForTest();
        //    var section = GetNewSectionForTest();

        //    Project.Sections.Add(section);

        //    int projectNumberBefore = taiJiDBContext.Set<ProjectVO>().Count();
        //    int sectionNumberBefore = taiJiDBContext.Set<SectionVO>().Count();

        //    mProjectRepository.Insert(Project);

        //    int projectNumberAfter = taiJiDBContext.Set<ProjectVO>().Count();
        //    int sectionNumberAfter = taiJiDBContext.Set<SectionVO>().Count();

        //    Assert.IsTrue(projectNumberAfter - projectNumberBefore == 1);
        //    Assert.IsTrue(sectionNumberAfter - sectionNumberBefore == 1);
        //}

        //[TestMethod]
        //public void CreateProjectWithThreeSections_Should_PersistBothProjectAndThreeSections()
        //{
        //    var Project = GetNewProjectForTest();
        //    var section = GetNewSectionForTest();
        //    var section2 = GetNewSectionForTest();
        //    var section3 = GetNewSectionForTest();

        //    Project.Sections.Add(section);
        //    Project.Sections.Add(section2);
        //    Project.Sections.Add(section3);

        //    int projectNumberBefore = taiJiDBContext.Set<ProjectVO>().Count();
        //    int sectionNumberBefore = taiJiDBContext.Set<SectionVO>().Count();

        //    mProjectRepository.Insert(Project);

        //    int projectNumberAfter = taiJiDBContext.Set<ProjectVO>().Count();
        //    int sectionNumberAfter = taiJiDBContext.Set<SectionVO>().Count();

        //    Assert.IsTrue(projectNumberAfter - projectNumberBefore == 1);
        //    Assert.IsTrue(sectionNumberAfter - sectionNumberBefore == 3);
        //}


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
