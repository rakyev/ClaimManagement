using ICM.Data.Business.Projection;
using ICM.Data.Business.RepositoryImplementation;
using System.Linq;

namespace ICM.Data.Business.BusinessObject
{
    public class ActivityBookingTypeBO : GenericRepository<ActivityBookingType>
    {
        public IQueryable<ActivityBookingTypePC> GetAppointmentResourceCountGroupedByActivityBookingType()
        {
            var result = from abt in Context.ActivityBookingTypes
                         join abbt in Context.ActivityBookingBookingTypes on abt.ActivityBookingTypeID equals abbt.ActivityBookingTypeID into abbtgroup
                         from abbt2 in abbtgroup.DefaultIfEmpty()
                         join ab in Context.ActivityBookings on abbt2.ActivityBookingID equals ab.ActivityBookingID into abgroup
                         from ab2 in abgroup.DefaultIfEmpty()
                         join ar in Context.AppointmentResources on ab2.AppointmentResourceID equals ar.AppointmentResourceID into argroup
                         from ar2 in argroup.DefaultIfEmpty()
                         select new
                         {
                             ActivityBookingTypeID = abt.ActivityBookingTypeID,
                             Description = abt.Description,
                             Code = abt.Code,
                             By = abt.By,
                             Active = abt.Active,
                             Version = abt.Version,
                             CreatedOrUpdated = abt.CreatedOrUpdated,
                             AppointmentResourceID = ar2.AppointmentResourceID
                         } into x
                         group x by new { x.ActivityBookingTypeID, x.Description, x.Code, x.By, x.Active, x.Version, x.CreatedOrUpdated }
                             into grp
                             select new ActivityBookingTypePC
                             {
                                 ActivityBookingTypeID = grp.Key.ActivityBookingTypeID,
                                 Description = grp.Key.Description,
                                 Code = grp.Key.Code,
                                 By = grp.Key.By,
                                 CreatedOrUpdated = grp.Key.CreatedOrUpdated,
                                 Version = grp.Key.Version,
                                 Active = grp.Key.Active,
                                 Count = grp.Count(x => x.AppointmentResourceID != null)
                             }; //grp.Select(x => x.ar.AppointmentResourceID).Distinct().Count() };


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
