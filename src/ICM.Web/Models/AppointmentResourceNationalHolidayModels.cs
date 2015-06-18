using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class AppointmentResourceNationalHolidayModels
    {
        [Key]
        public long AppointmentResourceNationalHolidayID { get; set; }

        [Display(Name = "Holiday Date")]
        [Required(ErrorMessage = "Holiday Date Required")]
        [DataType(DataType.Date)]
        public System.DateTime HolidayDate { get; set; }

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
        [Required(ErrorMessage  = "Updated Required")]
        [DataType(DataType.Date)]
        public System.DateTime CreatedOrUpdated { get; set; }
        
        [Required(ErrorMessage = "Version Required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Numbers only")]
        public int Version { get; set; }
        
        [Required(ErrorMessage = "Active Required")]
        public bool Active { get; set; }
    }
}