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
    
    public partial class SFSPreference
    {
        public int sp_pk { get; set; }
        public int sp_sproj_pk { get; set; }
        public long sp_WaitTimeAfterLoginFailure { get; set; }
        public int sp_MaxInvalidLoginAttempts { get; set; }
        public long sp_MaxInvalidLoginAttemptsTime { get; set; }
        public long sp_PwMinAge { get; set; }
        public long sp_PwMaxAge { get; set; }
        public int sp_PwMaxLength { get; set; }
        public int sp_PwMinLength { get; set; }
        public bool sp_PwAreComplex { get; set; }
        public int sp_PwBeforeRepeat { get; set; }
        public long sp_SessionTimeout { get; set; }
        public bool sp_AllowWindowsAuth { get; set; }
        public int sp_Version { get; set; }
    }
}