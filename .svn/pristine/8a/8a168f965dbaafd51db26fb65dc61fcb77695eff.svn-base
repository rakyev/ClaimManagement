using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class UserExtendedInformation
    {
        public UserExtendedInformation()
        {
            this.ClientCases = new HashSet<ClientCaseModels>();
        }

        [Key]
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string Ext { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string OtherPhone { get; set; }
        public long PreferredTheme { get; set; }
        public string Code { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<ClientCaseModels> ClientCases { get; set; }
    }
}