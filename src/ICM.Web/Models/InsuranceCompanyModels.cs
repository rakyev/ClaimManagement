using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class InsuranceCompany
    {
        public InsuranceCompany()
        {
            this.InsuranceCompanyBranches = new HashSet<InsuranceCompanyBranch>();
        }
        [Key]
        public long InsuranceCompanyID { get; set; }

        [Display(Name="Company Name")]
        [Required(ErrorMessage = "Company Name Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string CompanyName { get; set; }
       
        [Display(Name="IBC Insurer ID")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string IBCInsurerID { get; set; }

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

        public virtual ICollection<InsuranceCompanyBranch> InsuranceCompanyBranches { get; set; }
    }
}