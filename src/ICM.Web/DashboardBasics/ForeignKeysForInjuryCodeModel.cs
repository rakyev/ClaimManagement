using System.Collections.Generic;
using ICM.Data.Business.BusinessObject;
using ICM.Web.Infrastructure;
using ICM.Web.Models;

namespace ICM.Web.DashboardBasics
{
    public class ForeignKeysForInjuryCodeModel
    {
        public ForeignKeysForInjuryCodeModel()
        {
            var injuryObject = new InjuryCodeBO();
            injuryCodeCategoryTypeList = new List<InjuryCodeCategoryType>();

            ModelAdapter.GetConvertedModelList(injuryObject.GetInjuryCodeCategoryTypeList(), injuryCodeCategoryTypeList);
        }

        private List<InjuryCodeCategoryType> injuryCodeCategoryTypeList;

        public List<InjuryCodeCategoryType> GetInjuryCodeCategoryType()
        {
            return injuryCodeCategoryTypeList;
        }
    }
}