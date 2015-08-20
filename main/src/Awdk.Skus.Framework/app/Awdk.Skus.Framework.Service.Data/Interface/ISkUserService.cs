using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.Service.Data.Interface
{
    public interface ISkUserService
    {
        IEnumerable<SkUserVo> GetUsers();
    }
}
