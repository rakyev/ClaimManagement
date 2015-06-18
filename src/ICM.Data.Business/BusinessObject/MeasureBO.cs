using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class MeasureBO : GenericRepository<Measure>
    {
        //public override IQueryable<Measure> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<Measure>().OrderBy(item => item.MeasureID).Skip(skip).Take(take);
        //}
    }
}
