using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ICM.Web.Models
{
    public class ClientCaseClientModels
    {

        public CaseNote casenote { get; set; }
        [Key]
        public long CaseID { get; set; }
        public long ClientID { get; set; }
        [Display(Name = "CaseType")]
        public Int64 CaseTypeID { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime ReferralDate { get; set; }
        [Display(Name = "Coordinator")]
        public long CoordinatorUserID { get; set; }
        [Display(Name = "Updated")]
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        [Display(Name = "PostalCode")]
        public string PostalCodeOrZipCode { get; set; }


        public long CaseProviderID { get; set; }
        [Display(Name = "AppointmentResource")]
        public long AppointmentResourceID { get; set; }
        public string appFirstName { get; set; }
        public string By { get; set; }

        //Case Note
        public long CaseNoteID { get; set; }
        public string Subject { get; set; }
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
        public string CompletedBy { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> RemiderDate { get; set; }

        //Injury
        public long CaseInjuryID { get; set; }
        public string Code { get; set; }

        [Display(Name = "Type of Injury")]
        public string InjuryCodeID { get; set; }

        public string InjuryDescription { get; set; }

        //Case Acitvity

        public long CaseActivityID { get; set; }
        public long ActivityTypeID { get; set; }
        public string ActivityDescription { get; set; }
        public System.DateTime ActivityCreatedOrUpdated { get; set; }
        public bool ActivityActive { get; set; }
        public bool Completed { get; set; }

        //Case Contact
        public long CaseContactID { get; set; }
        [Display(Name = "ContactType")]
        public long CaseContactTypeID { get; set; }
        public long PrefixID { get; set; }
        [Display(Name = "FirstName")]
        public string ContactFirstName { get; set; }
        [Display(Name = "LastName")]
        public string ContactLastName { get; set; }
        public string MiddleName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        [Display(Name = "Province")]
        public long ProvinceOrStateID { get; set; }
        [Display(Name = "PostalCode")]
        public string ContactPostalCode { get; set; }
        public long CountryID { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string PersonalEmail { get; set; }
        public string CompanyName { get; set; }
        public string WorkPhone { get; set; }
        [Display(Name = "WorkPhone Ext")]
        public string WorkPhoneExtension { get; set; }
        public long CaseContactRelationshipID { get; set; }
        public long CaseContactSpecialityID { get; set; }
        public string WorkFax { get; set; }
        public string WorkEmail { get; set; }
        public bool ContactActive { get; set; }


        //Case Management
        public long CaseManagementID { get; set; }

        [Display(Name = "Doctype Type")]
        public int DocumentTypeID { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Display(Name = "New File Name")]
        public string NewFileName { get; set; }

        [Display(Name = "HCAID Status")]
        public string HCAIStatus { get; set; }

        [Display(Name = "Date of Service")]
        public DateTime DateOfService { get; set; }

        public int GoodAndServiceID { get; set; }

        [Display(Name = "Good and Service Att")]
        public string GoodAndServiceAtt { get; set; }

        [Display(Name = "Good and Service Description")]
        public string GoodAndServiceDesc { get; set; }

        public decimal Quantity { get; set; }

        public bool GSTHSTVAT { get; set; }
        public decimal LineCost { get; set; }
        public bool Billed { get; set; }
        public bool PSTOther { get; set; }
        public bool Visible { get; set; }

        public int MeasureID { get; set; }

        [Display(Name = "Plan Number")]
        public string PlanNumber { get; set; }

        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Display(Name = "Payment Amount")]
        public decimal PaymentAmount { get; set; }

        [Display(Name = "Billed Amount")]
        public decimal BilledAmount { get; set; }

        [Display(Name = "Approved Amount")]
        public decimal ApprovedAmount { get; set; }

        [Display(Name = "WIP Amount")]
        public decimal WIPAmount { get; set; }

        public long CaseBenefitID { get; set; }
        [Display(Name = "BenefitType")]
        public long BenefitTypeID { get; set; }
        [Display(Name = "Description")]
        public string BenefitDescription { get; set; }
        [Display(Name = "Active")]
        public bool BenefitActive { get; set; }


        public long CaseMVAID { get; set; }
        public System.DateTime DateofAccident { get; set; }
        public string ClaimNumber { get; set; }
        public string PolicyNumber { get; set; }
        [Display(Name = "Language")]
        public long LanguageID { get; set; }

        public string PolicyHolderFirstName { get; set; }
        public string PolicyHolderLastName { get; set; }
        [Display(Name = "Active")]
        public bool MVAActive { get; set; }



    }
}