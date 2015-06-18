using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICM.Data.Business.Projection
{
    public class ActivityBookingTypePC
    {
        public long Count { get; set; }

        public long ActivityBookingTypeID { get; set; }

        public string Description { get; set; }
        public string Code { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }
        
    }
}