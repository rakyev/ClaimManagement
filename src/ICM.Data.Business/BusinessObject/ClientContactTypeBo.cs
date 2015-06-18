using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

//Created by Femi 2015-02-08 03:38AM
namespace ICM.Data.Business.BusinessObject
{
    public class ClientContactTypeBO : GenericRepository<ClientContactType>
    {
        //public override IQueryable<ClientContactType> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<ClientContactType>().OrderBy(item => item.ClientContactTypeID).Skip(skip).Take(take);
        //}
    }
}
