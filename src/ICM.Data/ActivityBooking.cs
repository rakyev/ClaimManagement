//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ICM.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActivityBooking
    {
        public long ActivityBookingID { get; set; }
        public long CaseActivityID { get; set; }
        public string Description { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public long AppointmentResourceID { get; set; }
        public long ActivityID { get; set; }
        public string OutlookEntryId { get; set; }
        public string RelatedEntryId { get; set; }
        public long GoodAndServiceID { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public long Active { get; set; }
    
        public virtual AppointmentResource AppointmentResource { get; set; }
        public virtual CaseActivity CaseActivity { get; set; }
        public virtual GoodAndService GoodAndService { get; set; }
    }
}