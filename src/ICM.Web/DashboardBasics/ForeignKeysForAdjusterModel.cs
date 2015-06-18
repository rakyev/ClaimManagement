using System.Collections.Generic;
using ICM.Data.Business.BusinessObject;
using ICM.Web.Infrastructure;
using ICM.Web.Models;

namespace ICM.Web.DashboardBasics
{
    public class ForeignKeysForAdjusterModel
    {
        public ForeignKeysForAdjusterModel()
        {
            var adjusterObject = new AdjusterBO();

            InsuranceCompanyBranchList = new List<InsuranceCompanyBranch>();

            ModelAdapter.GetConvertedModelList(adjusterObject.GetInsuranceCompanyBranch(), InsuranceCompanyBranchList);
        }

        private List<InsuranceCompanyBranch> InsuranceCompanyBranchList;

        public List<InsuranceCompanyBranch> GetInsuranceCompanyBranch()
        {
            return InsuranceCompanyBranchList;
        }
    }
}