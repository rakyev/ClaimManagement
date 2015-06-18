using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class GoodAndService
    {
        public GoodAndService()
        {
            this.ActivityBookings = new HashSet<ActivityBookingModels>();
            this.CaseManagements = new HashSet<CaseManagement>();
        }
        [Key]
        public long GoodAndServiceID { get; set; }

        [Display(Name = "Good and Service Type")]
        [Required(ErrorMessage = "Good and Service Type Required")]
        public long GoodAndServiceTypeID { get; set; }

        [Required(ErrorMessage = "Description Required")]
        [StringLength(500, ErrorMessage = "Maximum 500 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Code Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Code { get; set; }
       
        [Required(ErrorMessage = "Fixed Required")]
        public bool Fixed { get; set; }

        [Required(ErrorMessage = "GST/HST/VAT Required")]
        public bool GSTHSTVAT { get; set; }

        [Required(ErrorMessage = "PST Other Required")]
        public bool PSTOther { get; set; }

        [Required(ErrorMessage = "Fee Required")]
        public decimal Fee { get; set; }
       
        [Display(Name = "Measure")]
        [Required(ErrorMessage = "Measure Required")]
        public long MeasureID { get; set; }

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

        public virtual ICollection<ActivityBookingModels> ActivityBookings { get; set; }
        public virtual ICollection<CaseManagement> CaseManagements { get; set; }
        public virtual GoodAndServiceType GoodAndServiceType { get; set; }
    }
}