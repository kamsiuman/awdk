using System.Linq;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Test.FakesDBContext.DbSet
{
    public class SkUserFakeDataSet : FakeDbSet<SkUserVo>
    {
        public override SkUserVo Find(params object[] keyValues)
        {
            var keyValue = (int)keyValues.FirstOrDefault();
            return this.SingleOrDefault(o => o.SkUserId == keyValue);
        }
    }
}


