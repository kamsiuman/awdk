using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awdk.Skus.Framework.DataAccess.EF.Interface;
using Awdk.Skus.Test.FakesDBContext.DbSet;
using Awdk.Skus.Framework.Entity.ValueObject;

namespace Slb.TaiJi.Test.FakesDBContext
{
    public class FakeSkusDBContext : ISkusDbContext
    {
        public FakeSkusDBContext()
        {
            SkUsers = new SkUserFakeDataSet();
        }

        public IDbSet<EventVo> Events { get; set; }
        public IDbSet<JobVo> Jobs { get; set; }
        public IDbSet<RoleTypeVo> RoleTypes { get; set; }
        public IDbSet<SkUserVo> SkUsers { get; set; }



        public DbSet<T> Set<T>() where T : class
        {
            throw new NotImplementedException();
            //return Set<T>();
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            throw new NotImplementedException();
            //this.Set<T>().Add(entity);
            //this.SaveChanges();
            //return entity<T>;


        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
