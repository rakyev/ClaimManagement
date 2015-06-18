using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class InjuryCode
    {
        public InjuryCode()
        {
            this.CaseInjuries = new HashSet<CaseInjury>();
        }
        [Key]
        public long InjuryCodeID { get; set; }
        
        [Display(Name="Injury Code Category")]
        [Required(ErrorMessage = "Injury Code Category Required")]
        public long InjuryCodeCategoryTypeID { get; set; }

        [Required(ErrorMessage = "Description Required")]
        [StringLength(500, ErrorMessage = "Maximum 500 characters")]
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

        public virtual ICollection<CaseInjury> CaseInjuries { get; set; }
        public virtual InjuryCodeCategoryType InjuryCodeCategoryType { get; set; }
    }
}