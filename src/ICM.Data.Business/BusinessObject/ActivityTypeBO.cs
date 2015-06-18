using System;
using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.RepositoryImplementation;
using System.Web;

namespace ICM.Data.Business.BusinessObject
{
    public class ActivityTypeBO : GenericRepository<ActivityType>
    {
        public List<ActivitySubType> GetActivitySubTypeList()
        {
            var query = from type in Context.ActivitySubTypes
                        select type;

            return query.ToList();
        }
    }
}
