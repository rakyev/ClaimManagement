using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class PaymentTypeBO : GenericRepository<PaymentType>
    {
        //public override IQueryable<PaymentType> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<PaymentType>().OrderBy(item => item.PaymentTypeID).Skip(skip).Take(take);
        //}
    }     
}
