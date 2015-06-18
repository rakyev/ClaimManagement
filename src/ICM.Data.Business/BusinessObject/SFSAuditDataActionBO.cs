using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class SFSAuditDataActionBO : GenericRepository<SFSAuditDataAction>
    {
        //public override IQueryable<SFSAuditDataAction> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<SFSAuditDataAction>().OrderBy(item => item.ada_pk).Skip(skip).Take(take);
        //}
        public List<SFSAuditDataAction> FillAll()
        {
            Context.Configuration.ProxyCreationEnabled = false;
            var results = from ada in Context.SFSAuditDataActions
                          orderby ada.ada_pk
                          select ada;
            if (results != null)
            {
                return results.ToList();
            }

            else
            {
                return null;
            }

        }

        public List<SFSAuditDataAction> FillByName(string name)
        {
            var result = from ada in Context.SFSAuditDataActions
                         orderby ada.ada_pk
                         where ada.ada_TableName.Contains(name.Trim())
                         select ada;
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
