using System;
using System.Collections.Generic;
using System.Linq;
using ICM.Data.Business.CountImplementation;
using ICM.Data.Business.RepositoryImplementation;
using ICM.Data.Business.Projection;

namespace ICM.Data.Business.BusinessObject
{
    public class AppointmentResourceBO : GenericRepository<AppointmentResource>
    {
        public List<AppointmentResourceBookingType> GetAppointmentResourceBookingTypeList()
        {
            var query = from appointmentResourceBookingType in Context.AppointmentResourceBookingTypes
                        select appointmentResourceBookingType;

            return query.ToList();
        }
        //todo--check where its being used
        public List<AppointmentResourceBookingType> GetAppointmentResourceBookingTypes()
        {
            var result = from types in Context.AppointmentResourceBookingTypes
                         select types;

            return result.ToList();
        }

        public int CountDoctorsByDateCreated(DateTime dateTime)
        {
            var count = Context.AppointmentResources.Count(s => s.CreatedOrUpdated == dateTime);
            return count;
        }

        public List<AppointmentResource> GetDoctorSearched(string des)
        {
            var query = from test in Context.AppointmentResources
                        where test.FirstName.Contains(des) || test.LastName.Contains(des) || test.CellPhone.Contains(des)
                        select test;

            return query.ToList();
        }

        public override void Add(AppointmentResource entity)
        {
            base.Add(entity);
            ClientCaseDoctorAppointmentCounts.DoctorCount++;

        }

        public override void Delete(AppointmentResource entity)
        {
            base.Delete(entity);
            ClientCaseDoctorAppointmentCounts.DoctorCount--;

        }

        public Boolean GetUniqueClient(String FirstName, String LastName, String HealthCardNumber)
        {
            IQueryable<ClientsPC> result = null;



            if ((String.IsNullOrWhiteSpace(HealthCardNumber) == false) && (String.IsNullOrWhiteSpace(FirstName) == false) && (String.IsNullOrWhiteSpace(LastName) == false))
            {
                result = (from cl in Context.Clients
                          where ((cl.FirstName == FirstName) && (cl.LastName == LastName) && (cl.HealthCardNumber == HealthCardNumber))
                          select new ClientsPC { ClienteID = cl.ClientID }).Distinct();
            }

            else
            {
                if (String.IsNullOrWhiteSpace(HealthCardNumber) == false)
                {
                    result = (from cl in Context.Clients
                              where ((cl.HealthCardNumber == HealthCardNumber))
                              select new ClientsPC { ClienteID = cl.ClientID }).Distinct();
                }
                else
                {

                    if ((String.IsNullOrEmpty(FirstName)) || (String.IsNullOrEmpty(LastName)))
                    {
                        result = (from cl in Context.Clients
                                  where ((cl.FirstName == FirstName) || (cl.LastName == LastName))
                                  select new ClientsPC { ClienteID = cl.ClientID }).Distinct();
                    }
                    else
                    {
                        result = (from cl in Context.Clients
                                  where ((cl.FirstName == FirstName) && (cl.LastName == LastName))
                                  select new ClientsPC { ClienteID = cl.ClientID }).Distinct();
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

        public IQueryable<AppointmentsResourcePC> GetAppointmentByClient(String FirstName, String LastName, String HealthCardNumber)
        {
            IQueryable<AppointmentsResourcePC> result = null;
            result = from activity in Context.ActivityBookings
                     join appointment in Context.AppointmentResources on activity.AppointmentResourceID equals appointment.AppointmentResourceID
                     join cases in Context.CaseActivities on activity.CaseActivityID equals cases.CaseActivityID
                     join c in Context.ClientCases on cases.CaseID equals c.CaseID
                     join cl in Context.Clients on c.ClientID equals cl.ClientID
                     select new AppointmentsResourcePC { AppointmentResourceID = appointment.AppointmentResourceID, ClientFirstName = cl.FirstName, ClientLastName = cl.LastName, DateofBirth = cl.DateofBirth, Address1 = cl.Address1, Address2 = cl.Address2, City = cl.City, HealthCardNumber = cl.HealthCardNumber, Comments = appointment.Comments, CreatedOrUpdated = appointment.CreatedOrUpdated, Description = appointment.Description, FirstName = appointment.FirstName, HomePhone = cl.HomePhone, LastName = appointment.LastName };


            if (String.IsNullOrWhiteSpace(HealthCardNumber) == false)
            {
                result = result.Where(hlth => hlth.HealthCardNumber == HealthCardNumber);
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
