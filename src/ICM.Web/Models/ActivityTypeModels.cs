﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class ActivityType
    {
        public ActivityType()
        {
            this.CaseActivities = new HashSet<CaseActivityModels>();
        }
        [Key]
        public long ActivityTypeID { get; set; }

        [Display(Name = "Activity Sub Type")]
        [Required(ErrorMessage = "Activity Sub Type Required")]
        public long ActivitySubTypeID { get; set; }

        [Required(ErrorMessage = "Description Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Letters and numbers only")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Code Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Code { get; set; }

        [Display(Name = "Good and Service")]
        [Required(ErrorMessage = "Good and Service Required")]
        public long GoodAndServiceID { get; set; }
       
        [Required(ErrorMessage = "By Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string By { get; set; }
        
        [Display(Name = "Updated")]
        [Required(ErrorMessage  = "Updated Required")]
        public System.DateTime CreatedOrUpdated { get; set; }
        
        [Required(ErrorMessage = "Version Required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Numbers only")]
        public int Version { get; set; }
        
        [Required(ErrorMessage = "Active Required")]
        public bool Active { get; set; }

        public virtual ActivitySubType ActivitySubType { get; set; }
        public virtual ICollection<CaseActivityModels> CaseActivities { get; set; }
    }
}