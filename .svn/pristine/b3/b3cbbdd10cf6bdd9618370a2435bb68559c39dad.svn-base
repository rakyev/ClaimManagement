using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class ProvinceOrState
    {
        public ProvinceOrState()
        {
            this.AppointmentResources = new HashSet<AppointmentResourceModels>();
            this.CaseContacts = new HashSet<CaseContact>();
            this.Clients = new HashSet<ClientModels>();
            this.ClientContacts = new HashSet<ClientContact>();
            this.Companies = new HashSet<Company>();
            this.CompanyBranches = new HashSet<CompanyBranch>();
        }
        [Key]
        [Display(Name = "Province")]
        public long ProvinceOrStateID { get; set; }

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

        public virtual ICollection<AppointmentResourceModels> AppointmentResources { get; set; }
        public virtual ICollection<CaseContact> CaseContacts { get; set; }
        public virtual ICollection<ClientModels> Clients { get; set; }
        public virtual ICollection<ClientContact> ClientContacts { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<CompanyBranch> CompanyBranches { get; set; }
    }
}