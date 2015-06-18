using ICM.Data.Business.RepositoryImplementation;
using System.Linq;
namespace ICM.Data.Business.BusinessObject
{
    public class SFSUsersXRolesBO: GenericRepository<SFSUsersXRole>
    {
        //public override IQueryable<SFSUsersXRole> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<SFSUsersXRole>().OrderBy(item => item.ur_pk).Skip(skip).Take(take);
        //}   
    }
}
