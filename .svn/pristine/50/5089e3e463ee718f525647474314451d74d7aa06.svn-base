using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class StandardInvoicePayment
    {
        [Key]
        public long StandardInvoicePaymentID { get; set; }
        public string Description { get; set; }
        public long StandardInvoiceID { get; set; }
        public long PaymentTypeID { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public bool Void { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        public virtual StandardInvoice StandardInvoice { get; set; }
    }
}