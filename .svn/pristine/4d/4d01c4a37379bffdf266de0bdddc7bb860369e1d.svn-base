using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class CaseMVA
    {
        [Key]
        public long CaseMVAID { get; set; }

        [Display(Name = "Case ID")]
        [Required]
        public long CaseID { get; set; }

        [Display(Name = "Accident Date")]
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime DateofAccident { get; set; }

        [Display(Name = "Claim Number")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string ClaimNumber { get; set; }

        [Display(Name = "Policy Number")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string PolicyNumber { get; set; }

        [Display(Name = "Adjuster")]
        [Required]
        public long AdjusterID { get; set; }

        [Required]
        public bool CAT { get; set; }

        [Display(Name = "Transport. Required")]
        [Required]
        public bool TransportationRequired { get; set; }

        [Display(Name = "Interpret. Required")]
        [Required]
        public bool InterpreterRequired { get; set; }

        [Display(Name = "Language")]
        [Required]
        public long LanguageID { get; set; }

        [Display(Name = "Same As Applicant")]
        [Required]
        public bool PolicyHolderSameAsApplicant { get; set; }

        [Display(Name = "Policy First Name")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string PolicyHolderFirstName { get; set; }

        [Display(Name = "Policy Last Name")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string PolicyHolderLastName { get; set; }

        [Display(Name = "Other Coverage?")]
        [Required]
        public bool IsThereOtherInsuranceCoverage { get; set; }

        [Required]
        public bool Closed { get; set; }

        [Display(Name = "Closed Date")]
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime ClosedDate { get; set; }

        [Display(Name = "Alt. Insurer Name")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Letters only")]
        public string OtherInsurer1Name { get; set; }

        [Display(Name = "Alt. Insurer Plan")]
        [Required]
        [StringLength(50)]
        public string OtherInsurer1Plan { get; set; }

        [Display(Name = "Alt. Policy No.")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string OtherInsurer1PolicyNumber { get; set; }

        [Display(Name = "Alt. Plan Member Name")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Letters only")]
        public string OtherInsurer1NameofThePlanMember { get; set; }

        [Display(Name = "Alt. Identifier")]
        [Required]
        [StringLength(50)]
        public string OtherInsurer1Identifier { get; set; }

        [Display(Name = "Alt. Insurer Name(2)")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Letters only")]
        public string OtherInsurer2Name { get; set; }

        [Display(Name = "Alt. Insurer Plan(2)")]
        [Required]
        [StringLength(50)]
        public string OtherInsurer2Plan { get; set; }

        [Display(Name = "Alt. Policy No.(2)")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string OtherInsurer2PolicyNumber { get; set; }

        [Display(Name = "Alt. Plan Member Name(2)")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Letters only")]
        public string OtherInsurer2NameofThePlanMember { get; set; }

        [Display(Name = "Alt. Identifier(2)")]
        [Required]
        [StringLength(50)]
        public string OtherInsurer2Identifier { get; set; }

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

        public virtual Adjuster Adjuster { get; set; }
        public virtual ClientCaseModels ClientCase { get; set; }
        public virtual Language Language { get; set; }
    }
}