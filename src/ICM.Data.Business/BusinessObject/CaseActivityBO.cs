using System.Collections.Generic;
using ICM.Data.Business.RepositoryImplementation;
using System.Linq;

//Created by Femi 2015-02-08 02:15AM
namespace ICM.Data.Business.BusinessObject
{
    public class CaseActivityBO : GenericRepository<CaseActivity>
    {
        public List<CaseActivity> GetCaseActivitybyCaseId(long? id)
        {
            var result = from ca in Context.CaseActivities
                         where ca.CaseID == id
                         select ca;
            return result.ToList();
        }
        
    }
}
