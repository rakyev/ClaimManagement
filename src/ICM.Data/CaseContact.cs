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
    
    public partial class CaseContact
    {
        public long CaseContactID { get; set; }
        public long CaseContactTypeID { get; set; }
        public long CaseID { get; set; }
        public long PrefixID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long ProvinceOrStateID { get; set; }
        public string PostalCodeOrZipCode { get; set; }
        public long CountryID { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string PersonalEmail { get; set; }
        public string CompanyName { get; set; }
        public string WorkPhone { get; set; }
        public string WorkPhoneExtension { get; set; }
        public string WorkFax { get; set; }
        public string WorkEmail { get; set; }
        public long CaseContactRelationshipID { get; set; }
        public long CaseContactSpecialityID { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }
    
        public virtual ClientCase ClientCase { get; set; }
        public virtual CaseContactRelationship CaseContactRelationship { get; set; }
        public virtual CaseContactSpeciality CaseContactSpeciality { get; set; }
        public virtual CaseContactType CaseContactType { get; set; }
        public virtual Country Country { get; set; }
        public virtual Prefix Prefix { get; set; }
        public virtual ProvinceOrState ProvinceOrState { get; set; }
    }
}
