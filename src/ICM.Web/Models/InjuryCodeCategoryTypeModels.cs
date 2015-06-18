using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class InjuryCodeCategoryType
    {
        public InjuryCodeCategoryType()
        {
            this.InjuryCodes = new HashSet<InjuryCode>();
        }
        [Key]
        public long InjuryCodeCategoryTypeID { get; set; }
        public long InjuryCodeSeriesTypeID { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<InjuryCode> InjuryCodes { get; set; }
        public virtual InjuryCodeSeriesType InjuryCodeSeriesType { get; set; }
    }
}