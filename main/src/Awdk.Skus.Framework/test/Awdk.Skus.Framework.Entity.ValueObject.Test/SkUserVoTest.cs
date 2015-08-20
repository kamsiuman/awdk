using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Awdk.Skus.Framework.Entity.ValueObject.Test
{
    [TestClass]
    public class SkUserVoTest
    {
        //private EventVo eventVo;
        //private JobVo jobVo;
        //private RoleTypeVo roleTypeVo;
        private SkUserVo skUserVo;

        [TestInitialize]
        public void SetUp()
        {
            skUserVo = new SkUserVo()
            {
                Alias = "awong5",
                RoleTypeId = 1,
                SkUserId = 2
            };
        }

        [TestMethod]
        public void SkUserVo_Should_NotNull()
        {
            Assert.IsNotNull(skUserVo);
        }

        [TestMethod]
        public void SkUserVoAlias_Should_SupportNullValue()
        {
            var result = new SkUserVo();
            Assert.IsNull(result.Alias);
        }


    }
}
