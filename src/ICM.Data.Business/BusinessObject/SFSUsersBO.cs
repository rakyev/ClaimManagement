using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class SFSUsersBO :GenericRepository<SFSUser>
    {     
        public List<SFSUser> GetByName(string name)
        {
            Context.Configuration.ProxyCreationEnabled = false;
            var result = from su in Context.SFSUsers
                         orderby su.us_FirstName
                         where su.us_FirstName.Contains(name.Trim()) || su.us_LastName.Contains(name.Trim()) || su.us_MiddleName.Contains(name.Trim())
                         select su;
            if (result != null)
            {
                return result.ToList();
            }

            else
            {
                return null;
            }
            
        }
        //public override IQueryable<SFSUser> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<SFSUser>().OrderBy(item => item.us_pk).Skip(skip).Take(take);
        //}
    }
}
