using ICM.Data.Business.RepositoryImplementation;
using System.Linq;

//Created by Femi 2015-02-08 02:46AM
namespace ICM.Data.Business.BusinessObject
{
    public class CaseContactSpecialityBO : GenericRepository<CaseContactSpeciality>
    {
        //public override IQueryable<CaseContactSpeciality> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<CaseContactSpeciality>().OrderBy(item => item.CaseContactSpecialityID).Skip(skip).Take(take);
        //}
    }
}
