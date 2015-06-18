using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class StandardInvoiceLineItem
    {
        [Key]
        public long StandardInvoiceLineItemID { get; set; }
        public long GoodAndServiceID { get; set; }
        public long AppointmentResourceID { get; set; }
        public string Attribute { get; set; }
        public decimal Quantity { get; set; }
        public string MeasureID { get; set; }
        public System.DateTime DateOfService { get; set; }
        public bool GSTHSTVAT { get; set; }
        public bool PSTOther { get; set; }
        public decimal LineCost { get; set; }
        public bool Void { get; set; }
        public long StandardInvoiceID { get; set; }
        public long CaseManagementID { get; set; }
        public long ActivityBookingID { get; set; }

        public virtual StandardInvoice StandardInvoice { get; set; }
    }
}