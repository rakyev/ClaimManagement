using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ICM.Data.Business.BusinessObject;
using ICM.Web.Infrastructure;
using ICM.Web.Models;

namespace ICM.Web.DashboardBasics
{
    public class ForeignKeysForAppointmentResourceModel
    {
        private AppointmentResourceBO _appointmentResourceBo;

        private List<AppointmentResourceBookingType> _appointmentResourceBookingTypes;

        public ForeignKeysForAppointmentResourceModel()
        {
            _appointmentResourceBo = new AppointmentResourceBO();
            _appointmentResourceBookingTypes = ModelAdapter.GetConvertedModelList(_appointmentResourceBo.GetAppointmentResourceBookingTypes(),
                    new List<AppointmentResourceBookingType>());
        }

        public List<AppointmentResourceBookingType> GetAppointmentResourceBookingTypes()
        {
            return _appointmentResourceBookingTypes;
        }
    }
}