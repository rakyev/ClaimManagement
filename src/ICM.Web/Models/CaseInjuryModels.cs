using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class CaseInjury
    {
        [Key]
        public long CaseInjuryID { get; set; }

        [Display(Name = "Case ID")]
        [Required]
        public long CaseID { get; set; }

        [Display(Name = "Injury")]
        [Required]
        public long InjuryCodeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

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
        public virtual InjuryCode InjuryCode { get; set; }
    }
}