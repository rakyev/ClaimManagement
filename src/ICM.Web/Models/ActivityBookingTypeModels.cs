﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class ActivityBookingTypeModels
    {
        [Key]
        public long ActivityBookingTypeID { get; set; }
        
        [Required(ErrorMessage = "Description Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [RegularExpression(@"^[\w ]+$", ErrorMessage = "Letters and numbers only")]
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
    }
}