using System;
using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;
using System.Web;

namespace ICM.Data.Business.BusinessObject
{
    public class InjuryCodeBO : GenericRepository<InjuryCode>
    {
        public List<InjuryCodeCategoryType> GetInjuryCodeCategoryTypeList()
        {
            var query = from type in Context.InjuryCodeCategoryTypes
                        select type;

            return query.ToList();
        }
    }
}
