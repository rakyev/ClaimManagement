using System.Collections.Generic;
using ICM.Data.Business.RepositoryImplementation;
using System.Linq;

//Created by Femi 2015-02-08 03:04AM
namespace ICM.Data.Business.BusinessObject
{
    public class CaseNoteBO : GenericRepository<CaseNote>
    {
        public List<CaseNote> GetCaseNoteByCaseId(long? id)
        {
            var results = from ci in Context.CaseNotes
                          where ci.CaseID == id
                          select ci;
            return results.ToList();
        }
    }
}
