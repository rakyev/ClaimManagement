using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class ClientCaseModels
    {
        public ClientCaseModels()
        {

            this.CaseActivities = new HashSet<CaseActivityModels>();
            this.CaseBenefits = new HashSet<CaseBenefit>();
            this.CaseContacts = new HashSet<CaseContact>();
            this.CaseInjuries = new HashSet<CaseInjury>();
            this.CaseManagements = new HashSet<CaseManagement>();
            this.CaseMVAs = new HashSet<CaseMVA>();
            this.CaseNotes = new HashSet<CaseNote>();
            this.CaseProviders = new HashSet<CaseProvider>();
            this.StandardInvoices = new HashSet<StandardInvoice>();
        }
        [Key]
        public long CaseID { get; set; }

        [Required]
        public long ClientID { get; set; }

        [Display(Name = "Case Type")]
        [Required]
        public long CaseTypeID { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[\w ]+$", ErrorMessage = "Letters and numbers only")]
        public string Description { get; set; }

        [Display(Name = "Referral Date")]
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime ReferralDate { get; set; }

        [Display(Name = "Coordinator User")]
        [Required]
        public long CoordinatorUserID { get; set; }

        [Display(Name = "Closed Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ClosedDate { get; set; }

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

        public virtual ICollection<CaseActivityModels> CaseActivities { get; set; }
        public virtual ICollection<CaseBenefit> CaseBenefits { get; set; }
        public virtual ICollection<CaseContact> CaseContacts { get; set; }
        public virtual ICollection<CaseInjury> CaseInjuries { get; set; }
        public virtual ICollection<CaseManagement> CaseManagements { get; set; }
        public virtual ICollection<CaseMVA> CaseMVAs { get; set; }
        public virtual ICollection<CaseNote> CaseNotes { get; set; }
        public virtual ICollection<CaseProvider> CaseProviders { get; set; }
        public virtual CaseType CaseType { get; set; }
        public virtual ClientModels Client { get; set; }
        public virtual UserExtendedInformation UserExtendedInformation { get; set; }
        public virtual ICollection<StandardInvoice> StandardInvoices { get; set; }
    }
}