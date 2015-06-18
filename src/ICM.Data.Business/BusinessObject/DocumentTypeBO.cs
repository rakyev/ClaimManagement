using System.Linq;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class DocumentTypeBO : GenericRepository<DocumentType>
    {
        //public override IQueryable<DocumentType> GetAll(int skip = 0, int take = 50)
        //{
        //    return Context.Set<DocumentType>().OrderBy(item => item.DocumentTypeID).Skip(skip).Take(take);
        //}
    }
}
