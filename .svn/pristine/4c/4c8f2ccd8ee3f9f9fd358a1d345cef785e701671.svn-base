using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;

namespace ICM.Web.Models
{
    public class CaseManagement
    {
        [Key]
        public long CaseManagementID { get; set; }

        [Display(Name = "Case ID")]
        [Required]
        public long CaseID { get; set; }

        [Display(Name = "Document Type")]
        public Nullable<long> DocumentTypeID { get; set; }

        [Display(Name = "File Name")]
        
        [StringLength(150)]
        [RegularExpression(@"[\w \d]+", ErrorMessage = "Letters and numbers only")]
        public string FileName { get; set; }

        [Display(Name = "New File Name")]
        [StringLength(150)]
        [RegularExpression(@"[\w \d]+", ErrorMessage = "Letters and numbers only")]
        public string NewFileName { get; set; }

        [Display(Name = "Case Activity")]
        public Nullable<long> CaseActivityID { get; set; }

        [Display(Name = "HCIS Status")]
        [Required]
        [StringLength(50)]
        public string HCAIStatus { get; set; }

        [Display(Name = "Service Date")]
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime DateOfService { get; set; }

        [Display(Name = "Good and Service")]
        [Required]
        public long GoodAndServiceID { get; set; }

        [Display(Name = "Good and Service Att.")]
        [Required]
        [StringLength(50)]
        public string GoodAndServiceAtt { get; set; }

        [Display(Name = "Description")]
        [Required]
        [StringLength(1000)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only")]
        public string GoodAndServiceDesc { get; set; }

        [Display(Name = "Appt. Resource")]
        [Required]
        public long AppointmentResourceID { get; set; }

        [Required]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "Decimals only")]
        public decimal Quantity { get; set; }

        [Display(Name = "Measure")]
        [Required]
        public long MeasureID { get; set; }

        [Display(Name = "GST/HST/VAT")]
        [Required]
        public bool GSTHSTVAT { get; set; }

        [Display(Name = "Line Cost")]
        [Required]
        [RegularExpression(@"\d+\.?\d*", ErrorMessage = "Decimals only")]
        public decimal LineCost { get; set; }

        [Required]
        public bool Billed { get; set; }

        [Display(Name = "PST Other")]
        [Required]
        public bool PSTOther { get; set; }

        [Display(Name = "Plan Number")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string PlanNumber { get; set; }

        [Display(Name = "Invoice No.")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string InvoiceNumber { get; set; }


        [Display(Name = "Payment Amount")]
        [Required]
        [RegularExpression(@"\d+\.?\d*", ErrorMessage = "Decimals only")]
        public decimal PaymentAmount { get; set; }

        [Display(Name = "Billed Amount")]
        [Required]
        [RegularExpression(@"\d+\.?\d*", ErrorMessage = "Decimals only")]
        public decimal BilledAmount { get; set; }

        [Display(Name = "Approved Amount")]
        [Required]
        [RegularExpression(@"\d+\.?\d*", ErrorMessage = "Decimals only")]
        public decimal ApprovedAmount { get; set; }

        [Required]
        public bool Visible { get; set; }

        [Display(Name = "WIP Amount")]
        [Required]
        [RegularExpression(@"\d+\.?\d*", ErrorMessage = "Decimals only")]
        public decimal WIPAmount { get; set; }

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
        public virtual CaseActivityModels CaseActivity { get; set; }
        public virtual ClientCaseModels ClientCase { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual GoodAndService GoodAndService { get; set; }
        public virtual Measure Measure { get; set; }
    }
}