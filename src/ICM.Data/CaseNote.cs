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
    
    public partial class CaseNote
    {
        public long CaseNoteID { get; set; }
        public long CaseID { get; set; }
        public long ClientID { get; set; }
        public string Subject { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreatedorUpdated { get; set; }
        public long Version { get; set; }
        public string By { get; set; }
        public string CompletedBy { get; set; }
        public Nullable<System.DateTime> RemiderDate { get; set; }
        public Nullable<bool> Private { get; set; }
        public string RemindUserID { get; set; }
    
        public virtual ClientCase ClientCase { get; set; }
    }
}