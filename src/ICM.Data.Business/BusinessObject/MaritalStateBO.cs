using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class MaritalStateBO : GenericRepository<MaritalState>
    {
        //public override IQueryable<MaritalState> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<MaritalState>().OrderBy(item => item.MaritalStatusID).Skip(skip).Take(take);
        //}
    }
}
