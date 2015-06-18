using ICM.Data.Business.RepositoryImplementation;
using System.Linq;

namespace ICM.Data.Business.BusinessObject
{
   public class SFSRolesXPermissionsBO :GenericRepository<SFSRolesXPermission>
    {
       //public override IQueryable<SFSRolesXPermission> GetAll(int skip = 0, int take = 50)
       //{
       //    return Context.Set<SFSRolesXPermission>().OrderBy(item => item.rp_pk).Skip(skip).Take(take);
       //}
    }
}
