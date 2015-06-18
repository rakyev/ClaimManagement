using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

//Created by Femi 2015-02-08 03:30AM
namespace ICM.Data.Business.BusinessObject
{
    public class ClientContactBO: GenericRepository<ClientContact>
    {
        //public override IQueryable<ClientContact> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<ClientContact>().OrderBy(item => item.ClientContactID).Skip(skip).Take(take);
        //}
    }
}
