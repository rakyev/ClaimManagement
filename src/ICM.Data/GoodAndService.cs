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
    
    public partial class GoodAndService
    {
        public GoodAndService()
        {
            this.ActivityBookings = new HashSet<ActivityBooking>();
            this.CaseManagements = new HashSet<CaseManagement>();
        }
    
        public long GoodAndServiceID { get; set; }
        public long GoodAndServiceTypeID { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool Fixed { get; set; }
        public bool GSTHSTVAT { get; set; }
        public bool PSTOther { get; set; }
        public decimal Fee { get; set; }
        public long MeasureID { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }
    
        public virtual ICollection<ActivityBooking> ActivityBookings { get; set; }
        public virtual ICollection<CaseManagement> CaseManagements { get; set; }
        public virtual GoodAndServiceType GoodAndServiceType { get; set; }
    }
}
