using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICM.Web.DashboardBasics
{
    public class ForeignKeysModelProxy
    {
        private static ForeignKeysForClientModel _clientforeignKeys;
        private static ForeignKeysForCaseModel _caseforeignKeys;
        private static ForeignKeysForActivityBookingModel _activityBookingforeignKeys;
        private static ForeignKeysForAppointmentResourceModel _appointmentForeignKeys;
        private static ForeignKeysForAdjusterModel _adjusterForeignKeys;
        private static ForeignKeysForGoodAndServiceModel _goodandserviceForeignKeys;
        private static ForeignKeysForInjuryCodeModel _injurycodeForeignKeys;
        private static ForeignKeysForActivityTypeModel _activitytypeForeignKeys;
        private ForeignKeysModelProxy(){}

        public static ForeignKeysForClientModel GetForeignKeysModelInstance()
        {
            return _clientforeignKeys ?? (_clientforeignKeys = new ForeignKeysForClientModel());
        }
        public static ForeignKeysForCaseModel GetClientCaseForeignKeysModelInstance()
        {
            return _caseforeignKeys ?? (_caseforeignKeys = new ForeignKeysForCaseModel());
        }

        public static ForeignKeysForActivityBookingModel GetActivityBookingsForeignKeysInstance()
        {
            return _activityBookingforeignKeys ?? (_activityBookingforeignKeys = new ForeignKeysForActivityBookingModel());
        }

        public static ForeignKeysForAppointmentResourceModel GetAppointmentResourceForeignKeysInstance()
        {
            return _appointmentForeignKeys ?? (_appointmentForeignKeys = new ForeignKeysForAppointmentResourceModel());
        }

        public ForeignKeysForAdjusterModel GetAdjusterForeignKeysInstance()
        {
            return _adjusterForeignKeys ?? (_adjusterForeignKeys = new ForeignKeysForAdjusterModel());
        }

        public static ForeignKeysForGoodAndServiceModel GetGoodAndServiceForeignKeysInstance()
        {
            return _goodandserviceForeignKeys ?? (_goodandserviceForeignKeys = new ForeignKeysForGoodAndServiceModel());
        }

        public static ForeignKeysForInjuryCodeModel GetInjuryCodeForeignKeysInstance()
        {
            return _injurycodeForeignKeys ?? (_injurycodeForeignKeys = new ForeignKeysForInjuryCodeModel());
        }

        public static ForeignKeysForActivityTypeModel GetActivityTypeForeignKeysInstance()
        {
            return _activitytypeForeignKeys ?? (_activitytypeForeignKeys = new ForeignKeysForActivityTypeModel());
        }
    }
}