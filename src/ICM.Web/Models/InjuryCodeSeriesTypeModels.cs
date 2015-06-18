using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class InjuryCodeSeriesType
    {
        public InjuryCodeSeriesType()
        {
            this.InjuryCodeCategoryTypes = new HashSet<InjuryCodeCategoryType>();
        }
        [Key]
        public long InjuryCodeSeriesTypeID { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string By { get; set; }
        public System.DateTime CreatedOrUpdated { get; set; }
        public int Version { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<InjuryCodeCategoryType> InjuryCodeCategoryTypes { get; set; }
    }
}