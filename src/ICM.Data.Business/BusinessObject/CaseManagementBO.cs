using System.Collections.Generic;
using ICM.Data.Business.RepositoryImplementation;
using System.Linq;

//Created by Femi 2015-02-08 02:56AM
namespace ICM.Data.Business.BusinessObject
{
    public class CaseManagementBO : GenericRepository<CaseManagement>
    {
        public List<CaseManagement> GetCaseManagementByCaseId(long? id)
        {
            var results = from ci in Context.CaseManagements
                          where ci.CaseID == id
                          select ci;
            return results.ToList();
        }
    }
}
