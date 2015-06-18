using System.Collections.Generic;
using ICM.Data.Business.RepositoryImplementation;
using System.Linq;

//Created by Femi 2015-02-08 03:00AM
namespace ICM.Data.Business.BusinessObject
{
    public class CaseMvaBO :  GenericRepository<CaseMVA>
    {
        public List<CaseMVA> GetCaseMVAByCaseId(long? id)
        {
            var results = from ci in Context.CaseMVAs
                          where ci.CaseID == id
                          select ci;
            return results.ToList();
        }
    }
}
