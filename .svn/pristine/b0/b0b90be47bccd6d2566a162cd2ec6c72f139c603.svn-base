using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class SFSAuditEventBO : GenericRepository<SFSAuditEvent>
    {
        //public override IQueryable<SFSAuditEvent> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<SFSAuditEvent>().OrderBy(item => item.ae_pk).Skip(skip).Take(take);
        //}
        public List<SFSAuditEvent> FillAll()
        {
            Context.Configuration.ProxyCreationEnabled = false;
            var results = from ae in Context.SFSAuditEvents
                          orderby ae.ae_pk
                          select ae;
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
