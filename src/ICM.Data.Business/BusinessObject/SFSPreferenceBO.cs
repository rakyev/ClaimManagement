using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class SFSPreferenceBO : GenericRepository<SFSPreference>
    {
        //public override IQueryable<SFSPreference> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<SFSPreference>().OrderBy(item => item.sp_pk).Skip(skip).Take(take);
        //}
        public List<SFSPreference> FillAll()
        {
            Context.Configuration.ProxyCreationEnabled = false;
            var results = from pref in Context.SFSPreferences
                          orderby pref.sp_pk
                          select pref;
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
