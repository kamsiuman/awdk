using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awdk.Skus.Framework.DataAccess.Repository.Interface;
using Awdk.Skus.Framework.Entity.ValueObject;
using Awdk.Skus.Framework.Service.Data.Interface;

namespace Awdk.Skus.Framework.Service.Data
{
    public class SkUserService : ISkUserService
    {
        private readonly ISkUserRepository skUserRepository;

        public SkUserService(ISkUserRepository skUserRepository)
        {
            this.skUserRepository = skUserRepository;
        }

        public IEnumerable<SkUserVo> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
