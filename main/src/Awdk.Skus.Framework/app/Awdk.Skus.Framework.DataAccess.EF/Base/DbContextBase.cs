using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Awdk.Skus.Framework.DataAccess.EF.Base
{
    public class DbContextBase<T> : DbContext where T : DbContext
    {
        public DbContextBase() : base("Name=SkusDbContext")
        {
            //Configuration.LazyLoadingEnabled = true;
            //Configuration.ProxyCreationEnabled = true;
            //Configuration.AutoDetectChangesEnabled = true;
        }
         
        static DbContextBase()
        {
            Database.SetInitializer<T>(null);
        }
    }

    //http://stackoverflow.com/questions/14033193/entity-framework-provider-type-could-not-be-loaded
    internal static class MissingDllHack
    {
        private static SqlProviderServices instance = SqlProviderServices.Instance;
    }
}


