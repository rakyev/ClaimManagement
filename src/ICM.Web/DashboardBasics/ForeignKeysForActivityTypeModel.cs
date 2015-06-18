using System.Collections.Generic;
using ICM.Data.Business.BusinessObject;
using ICM.Web.Infrastructure;
using ICM.Web.Models;

namespace ICM.Web.DashboardBasics
{
    public class ForeignKeysForActivityTypeModel
    {
        public ForeignKeysForActivityTypeModel()
        {
            var activityObject = new ActivityTypeBO();
            activitySubTypeList = new List<ActivitySubType>();

            ModelAdapter.GetConvertedModelList(activityObject.GetActivitySubTypeList(), activitySubTypeList);
        }

        private List<ActivitySubType> activitySubTypeList;

        public List<ActivitySubType> GetActivitySubType()
        {
            return activitySubTypeList;
        }
    }
}