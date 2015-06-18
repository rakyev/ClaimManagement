using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class GoodAndServiceTypeBO : GenericRepository<GoodAndServiceType>
    {
        //public override IQueryable<GoodAndServiceType> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<GoodAndServiceType>().OrderBy(item => item.GoodAndServiceTypeID).Skip(skip).Take(take);
        //}
    }
}
