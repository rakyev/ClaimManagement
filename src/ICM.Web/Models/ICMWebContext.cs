using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ICM.Web.Models
{
    public class ICMWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ICMWebContext() : base("name=ICMWebContext")
        {
        }
        public System.Data.Entity.DbSet<ICM.Web.Models.ClientModels> ClientModels { get; set; }

        public System.Data.Entity.DbSet<ICM.Web.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<ICM.Web.Models.Gender> Genders { get; set; }

        public System.Data.Entity.DbSet<ICM.Web.Models.MaritalState> MaritalStates { get; set; }

        public System.Data.Entity.DbSet<ICM.Web.Models.Prefix> Prefixes { get; set; }

        public System.Data.Entity.DbSet<ICM.Web.Models.ProvinceOrState> ProvinceOrStates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

        public System.Data.Entity.DbSet<ICM.Web.Models.ClientCaseModels> ClientCases { get; set; }

        public System.Data.Entity.DbSet<ICM.Web.Models.CaseType> CaseTypes { get; set; }


        public System.Data.Entity.DbSet<ICM.Web.Models.ClientCaseClientModels> ClientCaseClientModels { get; set; }


        public System.Data.Entity.DbSet<ICM.Web.Models.ActivityBookingModels> ActivityBookingModels { get; set; }

        public System.Data.Entity.DbSet<ICM.Web.Models.AppointmentResourceModels> AppointmentResources { get; set; }

        public System.Data.Entity.DbSet<ICM.Web.Models.CaseActivityModels> CaseActivities { get; set; }

        public System.Data.Entity.DbSet<ICM.Web.Models.GoodAndService> GoodAndServices { get; set; }

        public System.Data.Entity.DbSet<ICM.Web.Models.AppointmentResourceBookingType> AppointmentResourceBookingTypes { get; set; }

        public System.Data.Entity.DbSet<ICM.Web.Models.PaymentType> PaymentTypes { get; set; }
    }
}
