using System.Collections.Generic;
using ICM.Data.Business.BusinessObject;
using ICM.Web.Infrastructure;
using ICM.Web.Models;
namespace ICM.Web.DashboardBasics
{
    public class ForeignKeysForGoodAndServiceModel
    {
        public ForeignKeysForGoodAndServiceModel()
        {

            var serviceObject = new GoodAndServiceBO();
            GoodAndServiceTypeList = new List<GoodAndServiceType>();

            ModelAdapter.GetConvertedModelList(serviceObject.GetGoodAndServiceType(), GoodAndServiceTypeList);
        }

        private List<GoodAndServiceType> GoodAndServiceTypeList;

        public List<GoodAndServiceType> GetGoodAndServiceType()
        {
            return GoodAndServiceTypeList;
        }
        

    }
}