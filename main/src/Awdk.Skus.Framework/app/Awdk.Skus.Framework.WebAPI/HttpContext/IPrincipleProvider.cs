using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awdk.Skus.Framework.WebAPI.Controllers
{
    public interface IPrincipleProvider
    {
        string CurrentUserAlias { get; }
    }
}