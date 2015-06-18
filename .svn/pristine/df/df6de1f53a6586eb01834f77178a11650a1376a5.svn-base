using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class SFSRestrictionBO : GenericRepository<SFSRestriction>
    {
        //public override IQueryable<SFSRestriction> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<SFSRestriction>().OrderBy(item => item.rs_pk).Skip(skip).Take(take);
        //}
        public List<SFSRestriction> FillAll()
        {
           Context.Configuration.ProxyCreationEnabled = false;
            var results = from res in Context.SFSRestrictions
                          orderby res.rs_pk
                          select res;
            if (results != null)
            {
                return results.ToList();
            }

            else
            {
                return null;
            }

        }

        public List<SFSRestriction> FillByName(string name)
        {
            var result = from res in Context.SFSRestrictions
                         orderby res.rs_pk
                         where res.rs_Name.Contains(name.Trim())
                         select res;
            if (result != null)
            {
                return result.ToList();
            }

            else
            {
                return null;
            }

        }
    }
}
