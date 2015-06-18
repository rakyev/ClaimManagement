using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class AppointmentResourceAvailableTime
    {
        [Key]
        public long AppointmentResourceAvailableTimeID { get; set; }
        public Nullable<long> AppointmentResourceID { get; set; }
        public long DayofWeekID { get; set; }
        public System.TimeSpan AvailableFrom { get; set; }
        public System.TimeSpan AvailableTo { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }

        public virtual AppointmentResourceModels AppointmentResource { get; set; }
        public virtual DayofWeek DayofWeek { get; set; }
    }
}