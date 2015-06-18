using System.Collections.Generic;
using ICM.Data.Business.RepositoryImplementation;
using System.Linq;

//Created by Femi 2015-02-08 02:50AM
namespace ICM.Data.Business.BusinessObject
{
    public class CaseInjuryBO : GenericRepository<CaseInjury>
    {
        public List<CaseInjury> GetCaseInjuryByCaseId(long? id)
        {
            var results = from ci in Context.CaseInjuries
                          where ci.CaseID == id
                          select ci;
            return results.ToList();
        }
    }
}
