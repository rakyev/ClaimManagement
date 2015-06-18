using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class CaseNote
    {
        [Key]
        public long CaseNoteID { get; set; }

        [Display(Name = "Case ID")]
        [Required]
        public long CaseID { get; set; }

        [Required]
        public long ClientID { get; set; }

        [Required]
        [StringLength(521)]
        [RegularExpression(@"^[\w ]+$", ErrorMessage = "Letters and numbers only")]
        public string Subject { get; set; }

        [Required]
        [RegularExpression(@"^[\w ]+$", ErrorMessage = "Letters and numbers only")]
        public string Note { get; set; }

        [Required]
        public bool Active { get; set; }

        [Display(Name = "Updated")]
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime CreatedorUpdated { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Numbers only")]
        public long Version { get; set; }

        [Required]
        [StringLength(50)]
        public string By { get; set; }

        [Display(Name = "Completed By")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Letters only")]
        public string CompletedBy { get; set; }

        [Display(Name = "Reminder Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> RemiderDate { get; set; }

        public Nullable<bool> Private { get; set; }

        [Display(Name = "Reminder User")]
        public string RemindUserID { get; set; }

        public virtual ClientCaseModels ClientCase { get; set; }
    }
}