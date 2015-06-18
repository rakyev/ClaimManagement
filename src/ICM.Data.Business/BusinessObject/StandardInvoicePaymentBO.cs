using ICM.Data.Business.RepositoryImplementation;
using System.Linq;
namespace ICM.Data.Business.BusinessObject
{
    public class StandardInvoicePaymentBO:GenericRepository<StandardInvoicePayment>
    {
        //public override IQueryable<StandardInvoicePayment> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<StandardInvoicePayment>().OrderBy(item => item.StandardInvoicePaymentID).Skip(skip).Take(take);
        //}
    }
}