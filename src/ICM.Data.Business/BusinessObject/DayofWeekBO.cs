using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class DayofWeekBO : GenericRepository<DayofWeek>
    {
        //public override IQueryable<DayofWeek> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<DayofWeek>().OrderBy(item => item.DayofWeekID).Skip(skip).Take(take);
        //}
    }
}
