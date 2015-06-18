using System.Collections.Generic;
using ICM.Data.Business.BusinessObject;
using ICM.Web.Infrastructure;
using ICM.Web.Models;

namespace ICM.Web.DashboardBasics
{
    public class ForeignKeysForCaseModel
    {

        public ForeignKeysForCaseModel()
        {
            var caseObject = new ClientCaseBO();
            CaseTypeList = new List<CaseType>();
            UsersList = new List<UserExtendedInformation>();
            CaseActivityList = new List<ActivityType>();
            ContactTypeList = new List<CaseContactType>();
            BenefitList = new List<BenefitType>();
            ProviderList = new List<AppointmentResourceModels>();
            CaseInjuryList = new List<InjuryCode>();
            DocumentTypeList = new List<DocumentType>();
            GoodAndServiceList = new List<GoodAndService>();
            MeasureList = new List<Measure>();
            LanguageList = new List<Language>();
            AdjusterList = new List<Adjuster>();
            clientList = new List<ClientModels>();
            caseList = new List<ClientCaseModels>();
            contactRelationshipList = new List<CaseContactRelationship>();
            contactSpecialityList = new List<CaseContactSpeciality>();



            ModelAdapter.GetConvertedModelList(caseObject.GetLanguageList(), LanguageList);
            ModelAdapter.GetConvertedModelList(caseObject.GetAdjusterList(), AdjusterList);
            ModelAdapter.GetConvertedModelList(caseObject.GetClientList(), clientList);
            ModelAdapter.GetConvertedModelList(caseObject.GetCaseList(), caseList);
            ModelAdapter.GetConvertedModelList(caseObject.GetContactRelationshipList(), contactRelationshipList);
            ModelAdapter.GetConvertedModelList(caseObject.GetContactSpecialityList(), contactSpecialityList);



            ModelAdapter.GetConvertedModelList(caseObject.GetTypeList(), CaseTypeList);
            ModelAdapter.GetConvertedModelList(caseObject.GetCaseActivityList(), CaseActivityList);
            ModelAdapter.GetConvertedModelList(caseObject.GetContactTypeList(), ContactTypeList);
            ModelAdapter.GetConvertedModelList(caseObject.GetUsersList(), UsersList);
            ModelAdapter.GetConvertedModelList(caseObject.GetInjuryList(), CaseInjuryList);
            ModelAdapter.GetConvertedModelList(caseObject.GetDocumentList(), DocumentTypeList);
            ModelAdapter.GetConvertedModelList(caseObject.GetGoodAndServicesList(), GoodAndServiceList);
            ModelAdapter.GetConvertedModelList(caseObject.GetMeasureList(), MeasureList);
            ModelAdapter.GetConvertedModelList(caseObject.GetBenefitList(), BenefitList);
            ModelAdapter.GetConvertedModelList(caseObject.GetResourceList(), ProviderList);

        }

        private List<CaseType> CaseTypeList;
        private List<UserExtendedInformation> UsersList;
        private List<ActivityType> CaseActivityList;
        private List<CaseContactType> ContactTypeList;
        private List<ClientCaseModels> caseList;
        private List<CaseContactRelationship> contactRelationshipList;
        private List<CaseContactSpeciality> contactSpecialityList;


        private List<BenefitType> BenefitList;
        private List<AppointmentResourceModels> ProviderList;
        private List<InjuryCode> CaseInjuryList;
        private List<DocumentType> DocumentTypeList;
        private List<GoodAndService> GoodAndServiceList;
        private List<Measure> MeasureList;
        private List<Language> LanguageList;
        private List<ClientModels> clientList;
        private List<Adjuster> AdjusterList;



        public List<ClientModels> GetClientTypes()
        {
            return clientList;
        }
        public List<CaseContactRelationship> GetContactRelationshipTypes()
        {
            return contactRelationshipList;
        }
        public List<CaseContactSpeciality> GetContactSpecialityTypes()
        {
            return contactSpecialityList;
        }
        public List<ClientCaseModels> GetClientCaseTypes()
        {
            return caseList;
        }

        public List<CaseType> GetCaseTypes()
        {
            return CaseTypeList;
        }
        public List<ActivityType> GetActivities()
        {
            return CaseActivityList;
        }
        public List<CaseContactType> GetContactTypes()
        {
            return ContactTypeList;
        }
        public List<UserExtendedInformation> GetUsers()
        {
            return UsersList;
        }

        public List<BenefitType> GetBenefits()
        {
            return BenefitList;
        }

        public List<AppointmentResourceModels> GetProviders()
        {
            return ProviderList;
        }

        public List<InjuryCode> GetInjuries()
        {
            return CaseInjuryList;
        }

        public List<DocumentType> GetDocuments()
        {
            return DocumentTypeList;
        }

        public List<GoodAndService> GetGoodAndSerVices()
        {
            return GoodAndServiceList;
        }

        public List<Measure> GetMeasures()
        {
            return MeasureList;
        }
        public List<Language> GetLanguages()
        {
            return LanguageList;
        }
        public List<Adjuster> GetAdjusters()
        {
            return AdjusterList;
        }
    }
}