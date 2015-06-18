using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class AppointmentResourceModels
    {
        public AppointmentResourceModels()
        {
            this.ActivityBookings = new HashSet<ActivityBookingModels>();
            this.AppointmentResourceAvailableTimes = new HashSet<AppointmentResourceAvailableTime>();
            this.AppointmentResourceDayOffs = new HashSet<AppointmentResourceDayOff>();
            this.CaseManagements = new HashSet<CaseManagement>();
            this.CaseProviders = new HashSet<CaseProvider>();
        }
        [Key]
        [Display(Name = "Appointment Resource")]
        public long AppointmentResourceID { get; set; }

        [Display(Name = "Booking Type")]
        [Required(ErrorMessage = "Booking Type Required")]
        public long AppointmentResourceBookingTypeID { get; set; }

        [Display(Name = "Branch")]
        public Nullable<long> CompanyBranchID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage="Last Name Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Description Required")]
        [StringLength(50, ErrorMessage="Maximum 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string Description { get; set; }

        [Display(Name = "HCAI Provider")]
        [Required(ErrorMessage="HCAI Provider Required")]
        [StringLength(50, ErrorMessage="Maximum 50 characters")]
        public string HCAIProviderRegistryID { get; set; }

        [Display(Name = "Reg. No.")]
        [Required(ErrorMessage = "Reg. No. Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string CollegeRegistrationNumber { get; set; }

        [Display(Name = "Web Code")]
        [Required(ErrorMessage = "Web Code Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string WebAccessCode { get; set; }

        [Display(Name = "Dbl. Booking")]
        [Required(ErrorMessage="Dbl. Booking Required")]
        public bool DoubleBookingAllowed { get; set; }

        [Display(Name = "Address 1")]
        [Required(ErrorMessage= "Address 1 Required")]
        [StringLength(150, ErrorMessage = "Maximum 150 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        [Required(ErrorMessage =  "Address 2 Required")]
        [StringLength(150, ErrorMessage = "Maximum 150 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Address2 { get; set; }

        [Display(Name = "Address 3")]
        [Required(ErrorMessage = "Address 3 Required")]
        [StringLength(150, ErrorMessage = "Maximum 150 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Address3 { get; set; }

        [Required(ErrorMessage = "City Required")]
        [StringLength(60, ErrorMessage = "Maximum 60 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string City { get; set; }

        [Display(Name = "Province/State")]
        [Required(ErrorMessage = "Province/State Required")]
        public long ProvinceOrStateID { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage="Postal Code Required")]
        [StringLength(10, ErrorMessage = "Maximum 10 characters")]
        public string PostalCodeOrZipCode { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country Required")]
        public long CountryID { get; set; }

        [Display(Name = "Cell Phone")]
        [Required(ErrorMessage = "Cell Phone Required")]
        [StringLength(15, ErrorMessage = "Maximum 15 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string CellPhone { get; set; }

        [Display(Name = "Work Phone")]
        [Required(ErrorMessage = "Work Phone Required")]
        [StringLength(15, ErrorMessage = "Maximum 15 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string WorkPhone { get; set; }


        [Display(Name = "Work Ext.")]
        [Required(ErrorMessage = "Work Ext. Required")]
        [StringLength(10, ErrorMessage  = "Maximum 10 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string WorkPhoneExtension { get; set; }

        [Display(Name = "Work Fax")]
        [Required(ErrorMessage = "Work Fax Required")]
        [StringLength(15, ErrorMessage = "Maximum 15 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string WorkFax { get; set; }

        [Display(Name = "Other Phone")]
        [Required(ErrorMessage = "Other Number Required")]
        [StringLength(15, ErrorMessage = "Maximum 15 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string OtherPhone { get; set; }

        [Display(Name = "Work Email")]
        [Required(ErrorMessage = "Work Email Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [EmailAddress]     
        public string WorkEmail { get; set; }

        [Display(Name = "Alt. Email")]
        [Required(ErrorMessage = "Alt. Email Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [EmailAddress] 
        public string AdditionalEmail { get; set; }

        [Required(ErrorMessage = "Credentials Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Credentials { get; set; }

        [Required(ErrorMessage = "Comments Required")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Comments { get; set; }

        [Display(Name = "Resume Name")]
        [Required(ErrorMessage = "Resume Name Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string ResumeName { get; set; }
        
        [Required(ErrorMessage = "By Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string By { get; set; }

        [Display(Name = "Updated")]
        [DataType(DataType.Date)]
        [Required]
        public System.DateTime CreatedOrUpdated { get; set; }
       
        [Required(ErrorMessage = "Version Required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Numbers only")]
        public int Version { get; set; }
        
        [Required(ErrorMessage = "Active Required")]
        public bool Active { get; set; }

        public virtual ICollection<ActivityBookingModels> ActivityBookings { get; set; }
        public virtual AppointmentResourceBookingType AppointmentResourceBookingType { get; set; }
        public virtual Country Country { get; set; }
        public virtual ProvinceOrState ProvinceOrState { get; set; }
        public virtual ICollection<AppointmentResourceAvailableTime> AppointmentResourceAvailableTimes { get; set; }
        public virtual ICollection<AppointmentResourceDayOff> AppointmentResourceDayOffs { get; set; }
        public virtual ICollection<CaseManagement> CaseManagements { get; set; }
        public virtual ICollection<CaseProvider> CaseProviders { get; set; }
    }
}