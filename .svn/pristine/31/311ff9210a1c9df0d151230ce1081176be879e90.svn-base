using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class DoctorsAppointment
    {
        [Key]
        public long ActivityBookingID { get; set; }

        [Display(Name = "Doctors Name")]
        public string FirstName { get; set; }

        [Display(Name = "Case Activity")]
        public long CaseActivityID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Start Time")]
        public System.DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "End Time")]
        public System.DateTime EndTime { get; set; }

        [Display(Name = "Doctor")]
        public long AppointmentResourceID { get; set; }



        //[Display(Name = "Activity ID")]
        //public long ActivityID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        [Display(Name = "Outlook ID")]
        public string OutlookEntryId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        [Display(Name = "Related ID")]
        public string RelatedEntryId { get; set; }

        //[Display(Name = "Services")]
        
        //public long GoodAndServiceID { get; set; }
        [Required]
        public string By { get; set; }

        //[Display(Name = "Updated")]
        //[DataType(DataType.Date)]
        //public System.DateTime CreatedOrUpdated { get; set; }


        //public int Version { get; set; }


        public long Active { get; set; }

        //[RegularExpression(@"^[0-1 ]+$", ErrorMessage = "0 or 1 Only")]
        //public string FirstName { get; set; }

        //public virtual AppointmentResourceModels AppointmentResource { get; set; }
        //public virtual CaseActivityModels CaseActivity { get; set; }
        //public virtual GoodAndService GoodAndService { get; set; }
    }
}