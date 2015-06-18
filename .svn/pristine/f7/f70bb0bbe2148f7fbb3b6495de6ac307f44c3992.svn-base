using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject 
{
    public class SFSAuditActivityBO : GenericRepository<SFSAuditActivity>
    {
        //public override IQueryable<SFSAuditActivity> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<SFSAuditActivity>().OrderBy(item => item.sa_pk).Skip(skip).Take(take);
        //}
        public List<SFSAuditActivity> FillAll()
        {
            Context.Configuration.ProxyCreationEnabled = false;
            var results = from aa in Context.SFSAuditActivities
                          orderby aa.sa_pk
                          select aa;
            if (results != null)
            {
                return results.ToList();
            }

            else
            {
                return null;
            }

        }

        public List<SFSAuditActivity> FillByName(string name)
        {


            var result = from aa in Context.SFSAuditActivities
                         orderby aa.sa_FormName
                         where aa.sa_FormName.Contains(name.Trim())
                         select aa;
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
