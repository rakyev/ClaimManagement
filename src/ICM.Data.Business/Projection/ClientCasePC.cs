using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Data.Business.Projection
{
    public class ClientCasePC
    {
        public long CaseID { get; set; }
        public long ClientID { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string CellPhone { get; set; }
        public long CaseTypeID { get; set; }
        public string Description { get; set; }
        public System.DateTime ReferralDate { get; set; }
        public Nullable<System.DateTime> ClosedDate { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
    }
}
