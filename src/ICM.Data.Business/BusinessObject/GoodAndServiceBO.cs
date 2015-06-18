using System.Linq;
using ICM.Data.Business.RepositoryImplementation;
using System.Collections.Generic;

namespace ICM.Data.Business.BusinessObject
{
    public class GoodAndServiceBO : GenericRepository<GoodAndService>
    {
         public List<GoodAndServiceType> GetGoodAndServiceType()
        {
            var query = from type in Context.GoodAndServiceTypes
                        select type;

            return query.ToList();
        }
    }
}
