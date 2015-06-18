using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class StandardInvoice
    {
        public StandardInvoice()
        {
            this.StandardInvoiceLineItems = new HashSet<StandardInvoiceLineItem>();
            this.StandardInvoicePayments = new HashSet<StandardInvoicePayment>();
        }
        [Key]
        public long StandardInvoiceID { get; set; }
        public long CaseID { get; set; }
        public string Description { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GSTHSTVAT { get; set; }
        public decimal PSTOther { get; set; }
        public decimal InterestProposed { get; set; }
        public decimal MOH { get; set; }
        public decimal OtherInsurer { get; set; }
        public decimal Total { get; set; }
        public string AdditionalComments { get; set; }
        public bool SyncToQB { get; set; }
        public bool Void { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }

        public virtual ClientCaseModels ClientCase { get; set; }
        public virtual ICollection<StandardInvoiceLineItem> StandardInvoiceLineItems { get; set; }
        public virtual ICollection<StandardInvoicePayment> StandardInvoicePayments { get; set; }
    }
}