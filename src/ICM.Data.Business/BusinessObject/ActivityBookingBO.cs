using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using ICM.Data.Business.CountImplementation;
using ICM.Data.Business.RepositoryImplementation;

namespace ICM.Data.Business.BusinessObject
{
    public class ActivityBookingBO : GenericRepository<ActivityBooking>
    {

        public List<AppointmentResource> GetAppointmentResources()
        {
            var result = from appoint in Context.AppointmentResources
                         select appoint;
            return result.ToList();
        }

        public List<CaseActivity> GetCaseActivities()
        {
            var result = from cases in Context.CaseActivities
                         select cases;
            return result.ToList();
        }


        public List<GoodAndService> GetGoodAndServices()
        {
            var result = from goods in Context.GoodAndServices
                         select goods;
            return result.ToList();
        }


        public int CountCaseByDateCreated(DateTime dateTime)
        {
            var count = Context.ActivityBookings.Count(s => s.CreatedOrUpdated == dateTime);
            return count;
        }

        //var results = from c in db.costumers
        //              where SqlMethods.Like(c.FullName, "%" + FirstName + "%," + LastName)
        //              select c;

        public List<Projection.ProjectionDoctorAppointment> GetAppointmentSearched(string des)
        {
            var query = from doctor in Context.AppointmentResources
                        join booking in Context.ActivityBookings
                        on doctor.AppointmentResourceID equals booking.AppointmentResourceID
                        where doctor.FirstName.Contains(des) || doctor.LastName.Contains(des)

                        select new Projection.ProjectionDoctorAppointment
                        
                        {
                            Description = booking.Description,
                            StartTime = booking.StartTime,
                            EndTime = booking.EndTime,
                            OutlookEntryId = booking.OutlookEntryId,
                            RelatedEntryId = booking.RelatedEntryId,
                            By = booking.By,
                            FirstName = doctor.FirstName,
                            ActivityBookingID = booking.ActivityBookingID

                        };
           

            return query.ToList();
        }


        public override void Add(ActivityBooking entity)
        {
            base.Add(entity);
            ClientCaseDoctorAppointmentCounts.AppointmentCount++;

        }

        public override void Delete(ActivityBooking entity)
        {
            base.Delete(entity);
            ClientCaseDoctorAppointmentCounts.AppointmentCount--;

        }
    }
}