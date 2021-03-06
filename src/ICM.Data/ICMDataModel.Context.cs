﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ICM.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ICMDBContext : DbContext
    {
        public ICMDBContext()
            : base("name=ICMDBContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActivityBooking> ActivityBookings { get; set; }
        public virtual DbSet<ActivityBookingBookingType> ActivityBookingBookingTypes { get; set; }
        public virtual DbSet<ActivityBookingType> ActivityBookingTypes { get; set; }
        public virtual DbSet<ActivitySubType> ActivitySubTypes { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<Adjuster> Adjusters { get; set; }
        public virtual DbSet<AppointmentResource> AppointmentResources { get; set; }
        public virtual DbSet<AppointmentResourceAvailableTime> AppointmentResourceAvailableTimes { get; set; }
        public virtual DbSet<AppointmentResourceBookingType> AppointmentResourceBookingTypes { get; set; }
        public virtual DbSet<AppointmentResourceChargeOutRate> AppointmentResourceChargeOutRates { get; set; }
        public virtual DbSet<AppointmentResourceChargeOutType> AppointmentResourceChargeOutTypes { get; set; }
        public virtual DbSet<AppointmentResourceDayOff> AppointmentResourceDayOffs { get; set; }
        public virtual DbSet<AppointmentResourceNationalHoliday> AppointmentResourceNationalHolidays { get; set; }
        public virtual DbSet<AppointmentResourceResourceType> AppointmentResourceResourceTypes { get; set; }
        public virtual DbSet<AppointmentResourceType> AppointmentResourceTypes { get; set; }
        public virtual DbSet<BenefitType> BenefitTypes { get; set; }
        public virtual DbSet<CaseActivity> CaseActivities { get; set; }
        public virtual DbSet<CaseBenefit> CaseBenefits { get; set; }
        public virtual DbSet<CaseContact> CaseContacts { get; set; }
        public virtual DbSet<CaseContactRelationship> CaseContactRelationships { get; set; }
        public virtual DbSet<CaseContactSpeciality> CaseContactSpecialities { get; set; }
        public virtual DbSet<CaseContactType> CaseContactTypes { get; set; }
        public virtual DbSet<CaseInjury> CaseInjuries { get; set; }
        public virtual DbSet<CaseManagement> CaseManagements { get; set; }
        public virtual DbSet<CaseMVA> CaseMVAs { get; set; }
        public virtual DbSet<CaseNote> CaseNotes { get; set; }
        public virtual DbSet<CaseProvider> CaseProviders { get; set; }
        public virtual DbSet<CaseType> CaseTypes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientCase> ClientCases { get; set; }
        public virtual DbSet<ClientContact> ClientContacts { get; set; }
        public virtual DbSet<ClientContactRelationship> ClientContactRelationships { get; set; }
        public virtual DbSet<ClientContactSpeciality> ClientContactSpecialities { get; set; }
        public virtual DbSet<ClientContactType> ClientContactTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyBranch> CompanyBranches { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DayofWeek> DayofWeeks { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<GoodAndService> GoodAndServices { get; set; }
        public virtual DbSet<GoodAndServiceType> GoodAndServiceTypes { get; set; }
        public virtual DbSet<InjuryCode> InjuryCodes { get; set; }
        public virtual DbSet<InjuryCodeCategoryType> InjuryCodeCategoryTypes { get; set; }
        public virtual DbSet<InjuryCodeSeriesType> InjuryCodeSeriesTypes { get; set; }
        public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public virtual DbSet<InsuranceCompanyBranch> InsuranceCompanyBranches { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<MaritalState> MaritalStates { get; set; }
        public virtual DbSet<Measure> Measures { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Prefix> Prefixes { get; set; }
        public virtual DbSet<ProvinceOrState> ProvinceOrStates { get; set; }
        public virtual DbSet<SFSAuditDataAction> SFSAuditDataActions { get; set; }
        public virtual DbSet<SFSAuditDataField> SFSAuditDataFields { get; set; }
        public virtual DbSet<SFSAuditEvent> SFSAuditEvents { get; set; }
        public virtual DbSet<SFSPermission> SFSPermissions { get; set; }
        public virtual DbSet<SFSPreference> SFSPreferences { get; set; }
        public virtual DbSet<SFSProject> SFSProjects { get; set; }
        public virtual DbSet<SFSRestrictionItem> SFSRestrictionItems { get; set; }
        public virtual DbSet<SFSRestriction> SFSRestrictions { get; set; }
        public virtual DbSet<SFSRole> SFSRoles { get; set; }
        public virtual DbSet<SFSRolesXPermission> SFSRolesXPermissions { get; set; }
        public virtual DbSet<SFSUser> SFSUsers { get; set; }
        public virtual DbSet<SFSUsersXPermission> SFSUsersXPermissions { get; set; }
        public virtual DbSet<SFSUsersXRole> SFSUsersXRoles { get; set; }
        public virtual DbSet<SkedulexMessage> SkedulexMessages { get; set; }
        public virtual DbSet<StandardInvoice> StandardInvoices { get; set; }
        public virtual DbSet<StandardInvoiceLineItem> StandardInvoiceLineItems { get; set; }
        public virtual DbSet<StandardInvoicePayment> StandardInvoicePayments { get; set; }
        public virtual DbSet<UserExtendedInformation> UserExtendedInformations { get; set; }
        public virtual DbSet<SFSAuditActivity> SFSAuditActivities { get; set; }
    }
}
