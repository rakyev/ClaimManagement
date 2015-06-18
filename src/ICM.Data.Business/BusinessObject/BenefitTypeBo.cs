using ICM.Data.Business.RepositoryImplementation;
using System.Linq;

//Created by Femi 2015-02-08 01:59AM
namespace ICM.Data.Business.BusinessObject
{
    public class BenefitTypeBO : GenericRepository<BenefitType>
    {
        //public override IQueryable<BenefitType> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<BenefitType>().OrderBy(item => item.BenefitTypeID).Skip(skip).Take(take);
        //}
    }
}
