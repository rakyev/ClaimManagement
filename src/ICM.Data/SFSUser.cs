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
    
    public partial class SFSUser
    {
        public SFSUser()
        {
            this.SFSUsersXPermissions = new HashSet<SFSUsersXPermission>();
            this.SFSUsersXRoles = new HashSet<SFSUsersXRole>();
        }
    
        public int us_pk { get; set; }
        public int us_sproj_pk { get; set; }
        public string us_Username { get; set; }
        public string us_Data { get; set; }
        public string us_FirstName { get; set; }
        public string us_MiddleName { get; set; }
        public string us_LastName { get; set; }
        public string us_DisplayName { get; set; }
        public int us_Version { get; set; }
        public int us_CreatedBy { get; set; }
        public System.DateTime us_CreatedAt { get; set; }
    
        public virtual ICollection<SFSUsersXPermission> SFSUsersXPermissions { get; set; }
        public virtual ICollection<SFSUsersXRole> SFSUsersXRoles { get; set; }
    }
}