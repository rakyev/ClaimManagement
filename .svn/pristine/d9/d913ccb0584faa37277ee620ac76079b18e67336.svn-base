using System.Collections.Generic;
using ICM.Data.Business.RepositoryImplementation;
using System.Linq;

//Created by Femi 2015-02-08 02:35AM
namespace ICM.Data.Business.BusinessObject
{
    public class CaseContactBO : GenericRepository<CaseContact>
    {

         public List<CaseContact> GetCaseContactbyCaseId(long? id)
        {
            var results = from cc in Context.CaseContacts
                          where cc.CaseID == id
                          select cc;
            return results.ToList();
        }
    
    }
}
