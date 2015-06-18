using System;
using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;
using System.Web;

namespace ICM.Data.Business.BusinessObject
{
  /// <summary>
  /// This class provides with Adjuster information
  /// </summary>
    public class AdjusterBO : GenericRepository<Adjuster>
    {
        public List<InsuranceCompanyBranch> GetInsuranceCompanyBranch()
        {
            var query = from branch in Context.InsuranceCompanyBranches
                        select branch;

            return query.ToList();
        }
    }
}
