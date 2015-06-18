using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class CaseActivityModels
    {
        public CaseActivityModels()
        {
            this.ActivityBookings = new HashSet<ActivityBookingModels>();
            this.CaseManagements = new HashSet<CaseManagement>();
        }

        [Key]
        public long CaseActivityID { get; set; }

        [Display(Name = "Activity Type")]
        [Required]
        public long ActivityTypeID { get; set; }

        [Display(Name = "Case ID")]
        [Required]
        public long CaseID { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool Completed { get; set; }

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

        public virtual ICollection<ActivityBookingModels> ActivityBookings { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        public virtual ClientCaseModels ClientCase { get; set; }
        public virtual ICollection<CaseManagement> CaseManagements { get; set; }
    }
}