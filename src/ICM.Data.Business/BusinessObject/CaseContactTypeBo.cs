using ICM.Data.Business.RepositoryImplementation;
using System.Linq;

//Created by Femi 2015-02-08 02:46AM
namespace ICM.Data.Business.BusinessObject
{
    public class CaseContactTypeBO : GenericRepository<CaseContactType>
    {
        //public override IQueryable<CaseContactType> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<CaseContactType>().OrderBy(item => item.CaseContactTypeID).Skip(skip).Take(take);
        //}
    }
}
