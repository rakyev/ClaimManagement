using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class SFSPermissionBO : GenericRepository<SFSPermission>
    {
        //public override IQueryable<SFSPermission> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<SFSPermission>().OrderBy(item => item.pm_pk).Skip(skip).Take(take);
        //}
        public List<SFSPermission> GetByCategory(string category)
        {
            var result = (from per in Context.SFSPermissions
                          where per.pm_Category == category
                          select per);
            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return null;
            }

        }
        public List<SFSPermission> FillAll()
        {
            Context.Configuration.ProxyCreationEnabled = false;
            var results = from per in Context.SFSPermissions
                          orderby per.pm_pk
                          select per;
            if (results != null)
            {
                return results.ToList();
            }

            else
            {
                return null;
            }

        }

        
    }
}
