using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class CaseContact
    {
        [Key]
        public long CaseContactID { get; set; }

        [Display(Name = "Contact Type")]
        [Required]
        public long CaseContactTypeID { get; set; }

        [Display(Name = "Case ID")]
        [Required]
        public long CaseID { get; set; }

        [Display(Name = "Title")]
        [Required]
        public long PrefixID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [Required]
        [StringLength(60)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string MiddleName { get; set; }


        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string LastName { get; set; }

        [Display(Name = "Address 1")]
        [Required]
        [StringLength(150)]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        [Required]
        [StringLength(150)]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Address2 { get; set; }

        [Required]
        [StringLength(60)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string City { get; set; }

        [Display(Name = "Province/State")]
        [Required]
        public long ProvinceOrStateID { get; set; }

        [Display(Name = "Postal Code")]
        [Required]
        [StringLength(10)]
        public string PostalCodeOrZipCode { get; set; }

        [Display(Name = "Country")]
        [Required]
        public long CountryID { get; set; }

        [Display(Name = "Home Phone")]
        [Required]
        [StringLength(15)]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string HomePhone { get; set; }

        [Display(Name = "Cell Phone")]
        [Required]
        [StringLength(15)]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string CellPhone { get; set; }

        [Display(Name = "Personal Email")]
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string PersonalEmail { get; set; }

        [Display(Name = "Company Name")]
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }


        [Display(Name = "Work Phone")]
        [Required]
        [StringLength(15)]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string WorkPhone { get; set; }

        [Display(Name = "Work Phone Ext.")]
        [Required]
        [StringLength(10)]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string WorkPhoneExtension { get; set; }

        [Display(Name = "Work Fax")]
        [Required]
        [StringLength(15)]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string WorkFax { get; set; }

        [Display(Name = "Work Email")]
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string WorkEmail { get; set; }

        [Display(Name = "Contact Relationship")]
        [Required]
        public long CaseContactRelationshipID { get; set; }

        [Display(Name = "Contact Speciality")]
        [Required]
        public long CaseContactSpecialityID { get; set; }

        [Required]
        [StringLength(50)]
        public string By { get; set; }

        [Display(Name = "Updated")]
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime CreatedOrUpdated { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Numbers only")]
        public int Version { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual ClientCaseModels ClientCase { get; set; }
        public virtual CaseContactRelationship CaseContactRelationship { get; set; }
        public virtual CaseContactSpeciality CaseContactSpeciality { get; set; }
        public virtual CaseContactType CaseContactType { get; set; }
        public virtual Country Country { get; set; }
        public virtual Prefix Prefix { get; set; }
        public virtual ProvinceOrState ProvinceOrState { get; set; }
    }
}