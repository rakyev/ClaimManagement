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
    
    public partial class SFSUsersXRole
    {
        public int ur_pk { get; set; }
        public int ur_us_pk { get; set; }
        public int ur_rl_pk { get; set; }
        public int ur_CreatedBy { get; set; }
        public System.DateTime ur_CreatedAt { get; set; }
    
        public virtual SFSRole SFSRole { get; set; }
        public virtual SFSUser SFSUser { get; set; }
    }
}
