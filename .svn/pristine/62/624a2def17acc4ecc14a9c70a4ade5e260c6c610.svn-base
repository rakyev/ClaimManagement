using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class CaseProvider
    {
        [Key]
        public long CaseProviderID { get; set; }

        [Display(Name = "Case ID")]
        [Required]
        public long CaseID { get; set; }

        [Display(Name = "Appointment Resource")]
        [Required]
        public long AppointmentResourceID { get; set; }

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

        public virtual AppointmentResourceModels AppointmentResource { get; set; }
        public virtual ClientCaseModels ClientCase { get; set; }
    }
}