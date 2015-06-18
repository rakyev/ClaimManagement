using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class SFSProjectBO : GenericRepository<SFSProject>
    {
        //public override IQueryable<SFSProject> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<SFSProject>().OrderBy(item => item.sproj_pk).Skip(skip).Take(take);
        //}
        public List<SFSProject> FillAll()
        {
            Context.Configuration.ProxyCreationEnabled = false;
            var results = from proj in Context.SFSProjects
                          orderby proj.sproj_pk
                          select proj;
            if (results != null)
            {
                return results.ToList();
            }

            else
            {
                return null;
            }

        }

        public List<SFSProject> FillByName(string name)
        {
            var result = from proj in Context.SFSProjects
                         orderby proj.sproj_pk
                         where proj.sproj_Name.Contains(name.Trim())
                         select proj;
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
