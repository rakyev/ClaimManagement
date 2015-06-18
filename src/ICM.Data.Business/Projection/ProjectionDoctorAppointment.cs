using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Data.Business.Projection
{
    public class ProjectionDoctorAppointment
    {

        public string FirstName { get; set; }
        public long ActivityBookingID { get; set; }
        public long CaseActivityID { get; set; }
        public string Description { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
   
        //public long AppointmentResourceID { get; set; }
        //public long ActivityID { get; set; }
        public string OutlookEntryId { get; set; }
        public string RelatedEntryId { get; set; }

       

        //public long GoodAndServiceID { get; set; }
        public string By { get; set; }

        //[Display(Name = "Updated")]
        //[DataType(DataType.Date)]
        //public System.DateTime CreatedOrUpdated { get; set; }
        //public int Version { get; set; }
        public long Active { get; set; }

    }
}
