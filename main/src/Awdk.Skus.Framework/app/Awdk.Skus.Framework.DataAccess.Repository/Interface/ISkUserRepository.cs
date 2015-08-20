using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Awdk.Skus.Framework.DataAccess.Repository.Interface
{
    public interface ISkUserRepository
    {
        bool Authenticate(string userId, string password);
        SkUserVo GetById(int userId);
        SkUserVo GetUserByToken(string key);
        SkUserVo SelectByUserId(string userId);
        SkUserVo GetUserVoFromWorkspaceId(string userId);

    }
}
