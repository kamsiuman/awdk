using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.EF.Test
{
    [TestClass]
    public class SkusDBContextTest
    {
        [TestInitialize]
        public void SetUp()
        {
        }
        /// <summary>
        /// to Test/understand how the EF context state manager can handle the tracking of the 
        /// offline object using the Entry() method
        /// Expect      : Return correct state enum result.
        /// </summary>
        #region Tests - Context - DbSet Methods
        /// <summary>
        /// to check if the new domain object (offline created) is added to context, its EntityStates value should be "Added"
        /// </summary>
        [TestMethod]
        public void DbSetAttachNewCreatedEntity_Should_TheEntityStateValueSetToAdded()
        {
            var newSkUser = MockExistingSkUser();

            using (var context = new SkusDbContext())
            {
                context.SkUsers.Add(newSkUser);
                Assert.IsTrue(context.Entry(newSkUser).State == EntityState.Added);
            }
        }

        ///// <summary>
        ///// attaching the new offline entity object to context will have the states value set to updated
        ///// </summary>
        //[TestMethod]
        //public void DbSetAttachADisconnectiedUpdate_Should_TheEntityStateValueSetToAdded()
        //{
        //    var newProject = MockExistingProject();

        //    using (var context = new TaiJiDBContext())
        //    {
        //        context.Projects.Attach(newProject);
        //        context.Entry(newProject).State = EntityState.Modified;
        //        Assert.IsTrue(context.Entry(newProject).State == EntityState.Modified);
        //    }
        //}
        //#endregion

        ///// <summary>
        ///// to Test/understand how the EF context handle the instance notofication of 
        ///// change tracking and lazy loading throught Dynamic proxy virtual object property
        ///// </summary>
        //#region Tests - Context - Dynamic proxy and change tracking
        ///// <summary>
        ///// to check if the new domain object (offline created) is added to context, its EntityStates value should be "Added"
        ///// </summary>
        //[TestMethod]
        //public void DbSet_Should_InvokeDynamicProxyWithTheVirtualProperties()
        //{
        //    using (var context = new TaiJiDBContext())
        //    {
        //        var project = context.Projects.FirstOrDefault();
        //        Assert.IsTrue(project.GetType().FullName.StartsWith("System.Data.Entity.DynamicProxies"));
        //    }
        //}

        ///// <summary>
        ///// attaching the new offline entity object to context will have the states value set to updated
        ///// </summary>
        //[TestMethod]
        //public void DbSet_Should_EnableInstanceChangeTracking()
        //{
        //    using (var context = new TaiJiDBContext())
        //    {
        //        var project = context.Projects.FirstOrDefault();
        //        project.ProjectName = "abcde";
        //        context.ChangeTracker.DetectChanges();
        //        Assert.IsTrue(context.Entry(project).State == EntityState.Modified);
        //        //Assert.IsTrue(((context as IObjectContextAdapter).ObjectContext)
        //        //                 .ObjectStateManager.GetObjectStateEntries(EntityState.Modified).Count() == 1);
        //    }
        //}
        //#endregion

        ///// <summary>
        ///// to make sure the validation is triggered during the context save with the expected 
        ///// exception thrown
        ///// </summary>
        //#region Tests - Context Saved - validation
        ///// Test Condition : 
        ///// Condition   : Project contains invalid Properties "CreatedBy"
        ///// Expect      : Return DbValidationError Exception
        ///// </summary>
        //[TestMethod]
        //public void ProjectCreatedBy_ShouldNot_AllowMoreThenFiftyChars()
        //{
        //    var project = GetNewProjectForTest_withCreatedByPropertyMoreThanFiftyCharacters();
        //    //condition check
        //    Assert.IsTrue(project.CreatedBy.Length > 50);

        //    var context = new TaiJiDBContext();

        //    try
        //    {
        //        context.Projects.Add(project);
        //        context.SaveChanges();
        //        Assert.Fail("Expected Exception was not thrown");
        //    }
        //    catch (DbEntityValidationException dbException)
        //    {
        //        //dbException.EntityValidationErrors.ToList<DbValidationError>()[0].PropertyName
        //        Assert.AreEqual(dbException.ToString().StartsWith("System.Data.Entity.Validation.DbEntityValidationException: Validation failed for one or more entities"), true);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail("Expected Exception was not thrown; General Exception is thrown instead");
        //    }
        //}

        ///// Test Condition : 
        ///// Condition   : Project contains invalid Properties "ProjectName"
        ///// Expect      : Return DbValidationError Exception
        ///// </summary>
        //[TestMethod]
        //public void ProjectName_ShouldNot_AllowNULL()
        //{
        //    var project = GetNewProjectForTest_withCreatedByPropertyMoreThanFiftyCharacters();
        //    project.ProjectName = null;
        //    //condition check
        //    Assert.IsTrue(project.CreatedBy.Length > 50);
        //    var context = new TaiJiDBContext();
        //    try
        //    {
        //        context.Projects.Add(project);
        //        context.SaveChanges();
        //        Assert.Fail("Expected Exception was not thrown");
        //    }
        //    catch (DbEntityValidationException dbException)
        //    {
        //        //dbException.EntityValidationErrors.ToList<DbValidationError>()[0].PropertyName
        //        Assert.AreEqual(dbException.ToString().StartsWith("System.Data.Entity.Validation.DbEntityValidationException: Validation failed for one or more entities"), true);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail("Expected Exception was not thrown; General Exception is thrown instead");
        //    }
        //}
        #endregion

        #region sample Test data
        private SkUserVo MockExistingSkUser()
        {
            return new SkUserVo()
            {
                SkUserId = 1,
                Alias = "awong5",
                RoleTypeId = 1
            };
        }

        //private ProjectVO GetNewProjectForTest_withCreatedByPropertyMoreThanFiftyCharacters()
        //{
        //    return new ProjectVO()
        //    {
        //        ProjectName = "ProjectName1",
        //        WellName = "well_1",
        //        ClientName = "Client_1",
        //        RigName = "rig_1",
        //        WellId = 1,
        //        ClientId = 1,
        //        RigId = 1,
        //        CreatedBy = "Alex1Wong2Alex1Wong2Alex1Wong2Alex1Wong2Alex1Wong2Alex1Wong2",
        //        CreatedDate = DateTime.UtcNow,
        //        LastModifiedBy = "alex",
        //        LastModifiedDate = DateTime.UtcNow,
        //    };
        //}
        #endregion
    }
}