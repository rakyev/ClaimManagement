using ICM.Data.Business.RepositoryImplementation;
using System.Collections.Generic;
using System.Linq;
namespace ICM.Data.Business.BusinessObject
{
    public class CaseBenefitBO : GenericRepository<CaseBenefit>
    {
       public List<CaseBenefit> GetCaseBenefitByCaseId(long? id)
        {
            var results = from cb in Context.CaseBenefits
                          where cb.CaseID == id
                          select cb;
            return results.ToList();
        }
    }
}
