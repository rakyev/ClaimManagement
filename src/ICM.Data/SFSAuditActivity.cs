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
    
    public partial class SFSAuditActivity
    {
        public long sa_pk { get; set; }
        public int sa_us_pk { get; set; }
        public string sa_InternalIP { get; set; }
        public string sa_ExternalIP { get; set; }
        public string sa_FormName { get; set; }
        public byte sa_Action { get; set; }
        public long sa_cust_pk { get; set; }
        public long sa_cl_pk { get; set; }
        public System.DateTime sa_Created { get; set; }
        public int sa_CreatedBy { get; set; }
        public System.DateTime sa_CreatedorUpdated { get; set; }
        public long sa_Version { get; set; }
        public int sa_CreatedByorUpdatedBy { get; set; }
    }
}
