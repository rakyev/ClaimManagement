using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class InsuranceCompanyBranchBO : GenericRepository<InsuranceCompanyBranch>
    {
        //public override IQueryable<InsuranceCompanyBranch> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<InsuranceCompanyBranch>().OrderBy(item => item.InsuranceCompanyBranchID).Skip(skip).Take(take);
        //}
    }
}
