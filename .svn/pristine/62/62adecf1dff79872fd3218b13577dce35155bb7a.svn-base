using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

//Created by Femi 2015-02-08 03:10AM
namespace ICM.Data.Business.BusinessObject
{
    public class CaseProviderBO : GenericRepository<CaseProvider>
    {
        public List<CaseProvider> GetCaseProviderByCaseId(long? id)
        {
            var results = from ci in Context.CaseProviders
                          where ci.CaseID == id
                          select ci;
            return results.ToList();
        }
    }
}
