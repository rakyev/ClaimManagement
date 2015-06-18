using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class SFSAuditDataFieldBO : GenericRepository<SFSAuditDataField>
    {
        //public override IQueryable<SFSAuditDataField> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<SFSAuditDataField>().OrderBy(item => item.adf_pk).Skip(skip).Take(take);
        //}
        public List<SFSAuditDataField> FillAll()
        {
            Context.Configuration.ProxyCreationEnabled = false;
            var results = from adf in Context.SFSAuditDataFields
                          orderby adf.adf_pk
                          select adf;
            if (results != null)
            {
                return results.ToList();
            }

            else
            {
                return null;
            }

        }

        public List<SFSAuditDataField> FillByName(string name)
        {
            var result = from adf in Context.SFSAuditDataFields
                         orderby adf.adf_pk
                         where adf.adf_FieldName.Contains(name.Trim())
                         select adf;
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
