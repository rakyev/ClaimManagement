using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class UserExtendedInformationBO : GenericRepository<UserExtendedInformation>
    {
        //public override IQueryable<UserExtendedInformation> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<UserExtendedInformation>().OrderBy(item => item.UserID).Skip(skip).Take(take);
        //}
    }
}