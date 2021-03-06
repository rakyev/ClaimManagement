﻿using System;
﻿using System.Linq;
﻿using System.Web.Script.Serialization;
﻿using ICM.Data.Business.RepositoryImplementation;
using System.Collections.Generic;
﻿using ICM.Data.Business.CountImplementation;
using ICM.Data.Business.Projection;


namespace ICM.Data.Business.BusinessObject
{
    public class ClientCaseBO : GenericRepository<ClientCase>
    {
        public String GetClientandCases(string firstOrLastName)
        {
            var query = from client in Context.Clients
                join cases in Context.ClientCases
                    on client.ClientID equals cases.ClientID
                join type in Context.CaseTypes
                    on cases.CaseTypeID equals type.CaseTypeID
                where client.FirstName.Contains(firstOrLastName) || client
                    .LastName.Contains(firstOrLastName)
                select new
                {
                    cases.CaseID,
                    type.CaseTypeID,
                    cases.Description,
                    cases.By,
                    cases.ClientID,
                    cases.ReferralDate,
                    cases.CoordinatorUserID,
                    cases.CreatedOrUpdated,
                    cases.Version,
                    cases.Active,
                    client.FirstName,
                    client.LastName,
                    client.DateofBirth,
                    client.PostalCodeOrZipCode
                };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(query);

            return serializedResult;
        }

        public List<ClientCase> GetCaseList()
        {
            var query = from types in Context.ClientCases
                        select types;

            return query.ToList();
        }

        public Object GetAllClientandCases()
        {
            var query = from client in Context.Clients
                        join cases in Context.ClientCases
                        on client.ClientID equals cases.ClientID
                        join type in Context.CaseTypes
                        on cases.CaseTypeID equals type.CaseTypeID
                        select new { cases.CaseID, type.CaseTypeID, cases.Description, cases.By, cases.ClientID, client.FirstName, client.LastName, client.DateofBirth, client.PostalCodeOrZipCode };
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(query);
            return serializedResult;
        }

        public List<Projection.Client> GetClientbyCaseId(long? id)
        {
            var results = from client in Context.Clients
                          join cases in Context.ClientCases
                          on client.ClientID equals cases.ClientID
                          where cases.CaseID == id
                          select new Projection.Client
                          {
                              FirstName = client.FirstName,
                              LastName = client.LastName,
                              ClientId = client.ClientID
                          };
            return results.ToList();
        }
        
        public List<Client> GetClientList()
        {
            var query = from types in Context.Clients
                        select types;

            return query.ToList();
        }

        public List<CaseType> GetTypeList()
        {
            var query = from types in Context.CaseTypes
                select types;

            return query.ToList();
        }

        public List<ActivityType> GetCaseActivityList()
        {
            var query = from types in Context.ActivityTypes
                select types;

            return query.ToList();
        }

        public List<CaseContactType> GetContactTypeList()
        {
            var query = from types in Context.CaseContactTypes
                select types;

            return query.ToList();

        }
        public List<CaseContactRelationship> GetContactRelationshipList()
        {
            var query = from types in Context.CaseContactRelationships
                        select types;

            return query.ToList();
        }
        public List<CaseContactSpeciality> GetContactSpecialityList()
        {
            var query = from types in Context.CaseContactSpecialities
                        select types;

            return query.ToList();
        }

        public List<UserExtendedInformation> GetUsersList()
        {
            var query = from types in Context.UserExtendedInformations
                select types;

            return query.ToList();
        }

        public List<CaseProvider> GetProviderList()
        {
            var query = from types in Context.CaseProviders
                select types;

            return query.ToList();
        }

        public List<AppointmentResource> GetResourceList()
        {
            var query = from types in Context.AppointmentResources
                select types;

            return query.ToList();
        }

        public int CountCaseByDateCreated(DateTime dateTime)
        {
            var count = Context.ClientCases.Count(s => s.CreatedOrUpdated == dateTime);
            return count;
        }

        public List<BenefitType> GetBenefitList()
        {
            var query = from benefit in Context.BenefitTypes
                select benefit;

            return query.ToList();
        }

        public List<InjuryCode> GetInjuryList()
        {
            var query = from types in Context.InjuryCodes
                select types;

            return query.ToList();
        }

        public List<Language> GetLanguageList()
        {

            var query = from types in Context.Languages
                select types;

            return query.ToList();
        }

        public List<Adjuster> GetAdjusterList()
        {
            var query = from types in Context.Adjusters
                select types;

            return query.ToList();
        }

        public List<DocumentType> GetDocumentList()
        {
            var query = from types in Context.DocumentTypes
                select types;
            return query.ToList();
        }

        public List<GoodAndService> GetGoodAndServicesList()
        {
            var query = from types in Context.GoodAndServices
                select types;
            return query.ToList();
        }

        public List<Measure> GetMeasureList()
        {
            var query = from types in Context.Measures
                select types;
            return query.ToList();
        }

        public override void Add(ClientCase entity)
        {
            base.Add(entity);
            ClientCaseDoctorAppointmentCounts.CaseCount++;

        }

        public override void Delete(ClientCase entity)
        {
            base.Delete(entity);
            ClientCaseDoctorAppointmentCounts.CaseCount--;

        }

        public Boolean GetUniqueClient(String FirstName, String LastName, String PhoneNumber)
        {
            IQueryable<CasePC> result = null;



            if ((String.IsNullOrWhiteSpace(PhoneNumber) == false) && (String.IsNullOrWhiteSpace(FirstName) == false) && (String.IsNullOrWhiteSpace(LastName) == false))
            {
                result = (from cl in Context.Clients
                          where ((cl.FirstName == FirstName) && (cl.LastName == LastName) && (cl.CellPhone == PhoneNumber))
                          select new CasePC { ClientID = cl.ClientID }).Distinct();
            }

            else
            {
                if (String.IsNullOrWhiteSpace(PhoneNumber) == false)
                {
                    result = (from cl in Context.Clients
                              where ((cl.CellPhone == PhoneNumber))
                              select new CasePC { ClientID = cl.ClientID }).Distinct();
                }
                else
                {

                    if ((String.IsNullOrEmpty(FirstName)) || (String.IsNullOrEmpty(LastName)))
                    {
                        result = (from cl in Context.Clients
                                  where ((cl.FirstName == FirstName) || (cl.LastName == LastName))
                                  select new CasePC { ClientID = cl.ClientID }).Distinct();
                    }
                    else
                    {
                        result = (from cl in Context.Clients
                                  where ((cl.FirstName == FirstName) && (cl.LastName == LastName))
                                  select new CasePC { ClientID = cl.ClientID }).Distinct();
                    }


                }
            }
            int count = result.Count();
            if ((count > 1) || (count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IQueryable<ClientCasePC> GetAppointmentByClient(String FirstName, String LastName, String PhoneNumber)
        {
            IQueryable<ClientCasePC> result = null;
            result = from clientcase in Context.ClientCases
                     join client in Context.Clients on clientcase.ClientID equals client.ClientID
                     select new ClientCasePC
                     {
                         ClientID = client.ClientID,
                         ClientFirstName = client.FirstName,
                         ClientLastName = client.LastName,
                         By = clientcase.By,
                         CaseID = clientcase.CaseID,
                         CaseTypeID = clientcase.CaseTypeID,
                         ClosedDate = clientcase.ClosedDate,
                         CreatedOrUpdated = clientcase.CreatedOrUpdated,
                         Description = clientcase.Description,
                         ReferralDate = clientcase.ReferralDate,
                         CellPhone = client.CellPhone
                     };


            if (String.IsNullOrWhiteSpace(PhoneNumber) == false)
            {
                result = result.Where(ph => ph.CellPhone == PhoneNumber);
            }
            if ((String.IsNullOrWhiteSpace(FirstName) == false))
            {
                result = result.Where(fname => fname.ClientFirstName == FirstName);
            }

            if ((String.IsNullOrWhiteSpace(LastName) == false))
            {
                result = result.Where(lname => lname.ClientLastName == LastName);
            }

            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

    }
}