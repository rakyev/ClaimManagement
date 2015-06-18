using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class AppointmentResourceDayOff
    {
        [Key]
        public long AppointmentResourceDayOffID { get; set; }
        public long AppointmentResourceID { get; set; }
        public System.DateTime DayOffDate { get; set; }
        public System.TimeSpan DayOffFrom { get; set; }
        public System.TimeSpan DayOffTo { get; set; }
        public string Description { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }

        public virtual AppointmentResourceModels AppointmentResource { get; set; }
    }
}