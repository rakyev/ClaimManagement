using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
   public class ClientContact
    {
       [Key]
        public long ClientContactID { get; set; }
        public long ClientContactTypeID { get; set; }
        public long ClientID { get; set; }
        public string CompanyName { get; set; }
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
        public string WorkPhone { get; set; }
        public string WorkPhoneExtension { get; set; }
        public string WorkFax { get; set; }
        public string WorkEmail { get; set; }
        public long ClientContactRelationshipID { get; set; }
        public long ClientContactSpecialityID { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }
    
        public virtual ClientModels Client { get; set; }
        public virtual ClientContactRelationship ClientContactRelationship { get; set; }
        public virtual ClientContactSpeciality ClientContactSpeciality { get; set; }
        public virtual ClientContactType ClientContactType { get; set; }
        public virtual Country Country { get; set; }
        public virtual Prefix Prefix { get; set; }
        public virtual ProvinceOrState ProvinceOrState { get; set; }
    }
}