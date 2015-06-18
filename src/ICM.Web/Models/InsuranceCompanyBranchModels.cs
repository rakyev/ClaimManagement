using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class InsuranceCompanyBranch
    {
        public InsuranceCompanyBranch()
        {
            this.Adjusters = new HashSet<Adjuster>();
        }
        [Key]
        public long InsuranceCompanyBranchID { get; set; }
        
        [Display(Name = "Insurance Company")]
        [Required(ErrorMessage = "Insurance Company Required")]
        public long InsuranceCompanyID { get; set; }

        [Required(ErrorMessage = "Description Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Code Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "By Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string By { get; set; }

        [Display(Name = "Updated")]
        [Required(ErrorMessage = "Updated Required")]
        [DataType(DataType.Date)]
        public System.DateTime CreatedOrUpdated { get; set; }

        [Required(ErrorMessage = "Version Required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Numbers only")]
        public int Version { get; set; }

        [Required(ErrorMessage = "Active Required")]
        public bool Active { get; set; }
        
        [Display(Name="IBC Branch ID")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string IBCBranchID { get; set; }

        [Display(Name = "Address 1")]
        [Required(ErrorMessage = "Address 1 Required")]
        [StringLength(150, ErrorMessage = "Maximum 150 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        [Required(ErrorMessage = "Address 2 Required")]
        [StringLength(150, ErrorMessage = "Maximum 150 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "City Required")]
        [StringLength(60, ErrorMessage = "Maximum 60 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string City { get; set; }

        [Display(Name = "Province/State")]
        [Required(ErrorMessage = "Province/State Required")]
        public long ProvinceOrStateID { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Postal Code Required")]
        [StringLength(10, ErrorMessage = "Maximum 10 characters")]
        public string PostalCodeOrZipCode { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country Required")]
        public long CountryID { get; set; }

        [Required(ErrorMessage = "Phone Required")]
        [StringLength(15, ErrorMessage = "Maximum 15 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string Phone { get; set; }

        [Display(Name = "Phone Ext.")]
        [Required(ErrorMessage = "Phone Ext. Required")]
        [StringLength(10, ErrorMessage = "Maximum 10 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string PhoneExtension { get; set; }

        [Required(ErrorMessage = "Fax Required")]
        [StringLength(15, ErrorMessage = "Maximum 15 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string Fax { get; set; }
        
        [Required(ErrorMessage = "Email Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Adjuster> Adjusters { get; set; }
        public virtual InsuranceCompany InsuranceCompany { get; set; }
    }
}